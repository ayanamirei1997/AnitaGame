using LuaInterface;
using Anita.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anita
{
    
    // load scripts & constructs the fow chart tree
    [ExportCustomType]
    public class ScriptLoader
    {
        // Loader 是否已初始化
        private bool inited;
        
        // 初始化Loader , load 所有的 asset file，parse 所有 scripts，并构建 flow chart tree。
        public void Init(string path)
        {
            if (inited)
            {
                return;
            }

            ForceInit(path);

            inited = true;
        }

        private FlowChartTree flowChartTree;

        private FlowChartNode currentNode = null;

        // Current locale 
        public SystemLanguage stateLocale;

        private class LazyBindingEntry
        {
            public FlowChartNode from;
            public string destination;
            public BranchInformation branchInfo;
        }

        private List<LazyBindingEntry> lazyBindingLinks;

        private HashSet<string> onlyIncludedNames;

        private void InitOnlyIncludedNames()
        {
            onlyIncludedNames = new HashSet<string>(LuaRuntime.Instance
                .DoString<LuaTable>("return only_included_scenario_names").ToArray().Cast<string>());
        }

        public void ForceInit(string path)
        {
            flowChartTree = new FlowChartTree();
            currentNode = null;
            stateLocale = I18n.DefaultLocale;
            lazyBindingLinks = new List<LazyBindingEntry>();

            // 在调用 ParseScript() 之前执行 requires.lua
            // 并填充 ScriptDialogueEntryParser.PatternToActionGenerator
            LuaRuntime.Instance.BindObject("scriptLoader", this);
            InitOnlyIncludedNames();

            foreach (var locale in I18n.SupportedLocales)
            {
                stateLocale = locale;

                string localizedPath = path;
                if (locale != I18n.DefaultLocale)
                {
                    localizedPath = I18n.LocalePath + locale + "/" + path;
                }

                var scripts = Resources.LoadAll(localizedPath, typeof(TextAsset)).Cast<TextAsset>();
                foreach (var script in scripts)
                {
                    if (onlyIncludedNames.Count > 0 && !onlyIncludedNames.Contains(script.name))
                    {
                        continue;
                    }

#if UNITY_EDITOR
                    var scriptPath = AssetDatabase.GetAssetPath(script);
                    Debug.Log($"Anita: Parse script {scriptPath}");
#endif

                    try
                    {
                        ParseScript(script.text);
                    }
                    catch (ScriptParseException exception)
                    {
                        throw new ScriptParseException($"Failed to parse {script.name}", exception);
                    }
                }
            }

            // Bind all lazy binding entries
            BindAllLazyBindingEntries();

            // Perform sanity check
            flowChartTree.SanityCheck();

            // Construction finished, freeze the tree status
            flowChartTree.Freeze();
        }

        private void CheckInit()
        {
            Assert.IsTrue(inited, "Anita: ScriptLoader methods should be called after Init().");
        }
        
        // Get the flow chart tree
        public FlowChartTree GetFlowChartTree()
        {
            CheckInit();
            return flowChartTree;
        }

        private const string EagerExecutionStartSymbol = "@<|";
        private const string EagerExecutionBlockPattern = @"@<\|((?:.|[\r\n])*?)\|>";
        private const string EmptyLinePattern = @"(?:\r?\n\s*){2,}";

        // Parse script text
        private void ParseScript(string text)
        {
            LuaRuntime.Instance.DoString("action_new_file()");

            text = text.Trim();

            // Detect eager execution block
            int eagerExecutionStartIndex = text.IndexOf(EagerExecutionStartSymbol, StringComparison.Ordinal);
            if (eagerExecutionStartIndex != 0)
            {
                // The script file does not start with a eager execution block
                Debug.LogWarning("Anita: The script file does not start with a eager execution block. " +
                                 "All text before the first execution block will be removed.");
            }

            // No eager execution block is found, simply ignore this file
            if (eagerExecutionStartIndex < 0)
            {
                return;
            }

            text = text.Substring(eagerExecutionStartIndex);
            int lastMatchEndIndex = 0;
            foreach (Match m in Regex.Matches(text, EagerExecutionBlockPattern))
            {
                string flowChartNodeText = text.Substring(lastMatchEndIndex, m.Index - lastMatchEndIndex);
                // This method will not be executed when the execution enter this loop for the first time,
                // since the first eager execution block is definitely at the beginning of the text.
                ParseFlowChartNodeText(flowChartNodeText);
                lastMatchEndIndex = m.Index + m.Length;

                string eagerExecutionBlockCode = m.Groups[1].Value;
                // Debug.LogFormat("Eager code: <color=blue><b>{0}</b></color>", eagerExecutionBlockCode);
                DoEagerExecutionBlock(eagerExecutionBlockCode);
            }

            // A script file should ends with an eager execution block
            // Everything after the last eager execution block will be ignored
            if (lastMatchEndIndex < text.Length)
            {
                Debug.LogWarning("Anita: A script file should ends with a eager execution block, " +
                                 "which needs to refer to the next flow chart node.");
            }
        }
        
        // Parse the flow chart node
        private void ParseFlowChartNodeText(string flowChartNodeText)
        {
            if (flowChartNodeText == null)
            {
                return;
            }

            flowChartNodeText = flowChartNodeText.Trim();
            if (string.IsNullOrEmpty(flowChartNodeText))
            {
                return;
            }

            if (currentNode == null)
            {
                throw new ArgumentException("Anita: Dangling node text " + flowChartNodeText);
            }

            var dialogueEntryTexts = Regex.Split(flowChartNodeText, EmptyLinePattern);

            if (stateLocale == I18n.DefaultLocale)
            {
                var entries = ScriptDialogueEntryParser.ParseDialogueEntries(dialogueEntryTexts);
                currentNode.SetDialogueEntries(entries);
            }
            else
            {
                var entries = ScriptDialogueEntryParser.ParseLocalizedDialogueEntries(dialogueEntryTexts);
                currentNode.AddLocaleForDialogueEntries(stateLocale, entries);
            }
        }
        
        // Bind all lazy binding entries
        private void BindAllLazyBindingEntries()
        {
            foreach (var entry in lazyBindingLinks)
            {
                var node = entry.from;
                node.AddBranch(entry.branchInfo, flowChartTree.GetNode(entry.destination));
            }

            // Remove unnecessary reference
            lazyBindingLinks = null;
        }
        
        //  Execute code in the eager execution block
        private static void DoEagerExecutionBlock(string eagerExecutionBlockCode)
        {
            LuaRuntime.Instance.DoString(eagerExecutionBlockCode);
        }

        #region Methods called by external scripts
        
        // 创建一个新的 flow chart node，将其注册到当前正在构建的 FlowChartTree。
        // 如果当前节点是 normal node ，则新创建的 node 将作为其后续节点。
        // 新节点和当前节点之间的 link 会立即添加，不会注册为  lazy binding link。
        /// 该方法被设计为被脚本外部调用。
        public void RegisterNewNode(string name)
        {
            var nextNode = new FlowChartNode(name);
            if (currentNode != null && currentNode.type == FlowChartNodeType.Normal)
            {
                currentNode.AddBranch(BranchInformation.Default, nextNode);
            }

            currentNode = nextNode;

            // The try block here is to make debug info easier to read
            try
            {
                flowChartTree.AddNode(currentNode);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentException("Anita: A label must have a name");
            }
            catch (ArgumentException)
            {
                throw new DuplicatedDefinitionException(
                    $"Anita: Multiple definition of the same label {currentNode.name}");
            }
        }

        public void BeginAddLocaleForNode(string name)
        {
            currentNode = flowChartTree.GetNode(name);
        }
        
        // 注册一个 lazy binding link 并将当前节点设为 null。
        public void RegisterJump(string destination)
        {
            if (destination == null)
            {
                string msg = "Anita: jump_to instruction must have a destination.";
                msg += " Exception occurs at node: " + currentNode.name;
                throw new ArgumentException(msg);
            }

            if (currentNode.type == FlowChartNodeType.Branching)
            {
                throw new ArgumentException("Anita: Cannot apply jump_to() to a branching node.");
            }

            lazyBindingLinks.Add(new LazyBindingEntry
            {
                from = currentNode,
                destination = destination,
                branchInfo = BranchInformation.Default
            });

            currentNode = null;
        }

        // Add a branch to the current node.
        // 当前节点的类型将切换为 Branching。
        public void RegisterBranch(string name, string destination, string text, BranchImageInformation imageInfo,
            BranchMode mode, LuaFunction condition)
        {
            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentException(
                    $"Anita: A branch must have a destination. Exception occurs at node: {currentNode.name}, text: {text}");
            }

            if (mode == BranchMode.Normal && condition != null)
            {
                throw new ArgumentException(
                    $"Anita: Branch mode is Normal but condition is not null. Exception occurs at node: {currentNode.name}, destination: {destination}");
            }

            if (mode == BranchMode.Jump && (text != null || imageInfo != null))
            {
                throw new ArgumentException(
                    $"Anita: Branch mode is Jump but text or imageInfo is not null. Exception occurs at node: {currentNode.name}, destination: {destination}");
            }

            if ((mode == BranchMode.Show || mode == BranchMode.Enable) && condition == null)
            {
                throw new ArgumentException(
                    $"Anita: Branch mode is Show or Enable but condition is null. Exception occurs at node: {currentNode.name}, destination: {destination}");
            }

            currentNode.type = FlowChartNodeType.Branching;
            lazyBindingLinks.Add(new LazyBindingEntry
            {
                from = currentNode,
                destination = destination,
                branchInfo = new BranchInformation(name, text, imageInfo, mode, condition)
            });
        }
        
        // 停止向当前 node 注册 branch ，并将当前 node 设为 null 。
        public void EndRegisterBranch()
        {
            currentNode = null;
        }

        // Set the current node as a start node.
        public void SetCurrentAsStart(string name)
        {
            if (currentNode == null)
            {
                throw new ArgumentException(
                    $"Anita: SetCurrentAsStart({name}) should be called after registering the current node.");
            }

            if (name == null)
            {
                name = currentNode.name;
            }

            flowChartTree.AddStart(name, currentNode);
        }

        public void SetCurrentAsUnlockedStart(string name)
        {
            if (currentNode == null)
            {
                throw new ArgumentException(
                    $"Anita: SetCurrentAsUnlockedStart({name}) should be called after registering the current node.");
            }

            if (name == null)
            {
                name = currentNode.name;
            }

            SetCurrentAsStart(name);
            flowChartTree.AddUnlockedStart(name, currentNode);
        }

        // Set the current node as the default start node.
        public void SetCurrentAsDefaultStart(string name)
        {
            SetCurrentAsUnlockedStart(name);
            flowChartTree.defaultStartNode = currentNode;
        }
        
        // Set the current node as an end node.
        public void SetCurrentAsEnd(string name)
        {
            if (currentNode == null)
            {
                throw new ArgumentException(
                    $"Anita: SetCurrentAsEnd({name}) should be called after registering the current node.");
            }

            // Set the current node type as End
            currentNode.type = FlowChartNodeType.End;

            // Add the node as an end
            if (name == null)
            {
                name = currentNode.name;
            }

            flowChartTree.AddEnd(name, currentNode);

            // Null the current node, because SetCurrentAsEnd() indicates the end of a node
            currentNode = null;
        }

        #endregion
    }
}