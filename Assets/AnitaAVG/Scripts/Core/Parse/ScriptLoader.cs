/*
 * 解析自己的演出脚本
 */

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
    // 加载脚本和构建流程图树的类。
    [ExportCustomType]
    public class ScriptLoader
    {
        // 是否已初始化
        private bool inited;

        // 初始 ScriptLoader。
        // 此方法将 load 给定文件夹中的所有 text asset，
        // 解析所有脚本，并构建流程图树。
        // 包含所有脚本的文件夹的所有text都将被加载和解析，因此该文件夹中不应该有除脚本文件之外的asset。
        public void Init(string path)
        {
            if (inited)
            {
                return;
            }

            ForceInit(path);

            inited = true;
        }

        // 流程树
        private FlowChartTree flowChartTree;

        // 当前 node
        private FlowChartNode currentNode = null;

        // 系统语言
        public SystemLanguage stateLocale;

        // 节点去向
        private class LazyBindingEntry
        {
            public FlowChartNode from; // 来源
            public string destination; // 目的
            public BranchInformation branchInfo; // 分支信息
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

            // 在调用 ParseScript() 之前
            // 执行 requires.lua 并填充 ScriptDialogueEntryParser.PatternToActionGenerator
            LuaRuntime.Instance.BindObject("scriptLoader", this);
            InitOnlyIncludedNames();

            foreach (var locale in I18n.SupportedLocales)
            {
                // 本地化
                stateLocale = locale;
                string localizedPath = path;
                if (locale != I18n.DefaultLocale)
                {
                    localizedPath = I18n.LocalePath + locale + "/" + path;
                }

                // 加载所有自定义脚本
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
                        // 解析脚本
                        ParseScript(script.text);
                    }
                    catch (ScriptParseException exception)
                    {
                        throw new ScriptParseException($"Failed to parse {script.name}", exception);
                    }
                }
            }

            // 绑定所有节点流向关系
            BindAllLazyBindingEntries();

            // 执行健全性检查
            flowChartTree.SanityCheck();

            // 流程树构建完成，freeze 这个树
            flowChartTree.Freeze();
        }

        private void CheckInit()
        {
            Assert.IsTrue(inited, "Anita: ScriptLoader methods should be called after Init().");
        }

        // 返回流程树
        public FlowChartTree GetFlowChartTree()
        {
            CheckInit();
            return flowChartTree;
        }

        // 脚本的开头 ： @<| 
        private const string EagerExecutionStartSymbol = "@<|";
        // 脚本中有意义的结构体
        private const string EagerExecutionBlockPattern = @"@<\|((?:.|[\r\n])*?)\|>";
        // 脚本中的空行
        private const string EmptyLinePattern = @"(?:\r?\n\s*){2,}";

        // 解析 Script
        private void ParseScript(string text)
        {
            LuaRuntime.Instance.DoString("action_new_file()");

            text = text.Trim();

            // 优先执行 eager execution block
            int eagerExecutionStartIndex = text.IndexOf(EagerExecutionStartSymbol, StringComparison.Ordinal);
            if (eagerExecutionStartIndex != 0)
            {
                // 不以 eager execution block开头
                Debug.LogWarning("Anita: The script file does not start with a eager execution block. " +
                                 "All text before the first execution block will be removed.");
            }

            // 没有 eager execution block， 直接跳过
            if (eagerExecutionStartIndex < 0)
            {
                return;
            }

            text = text.Substring(eagerExecutionStartIndex);
            int lastMatchEndIndex = 0;
            foreach (Match m in Regex.Matches(text, EagerExecutionBlockPattern))
            {
                string flowChartNodeText = text.Substring(lastMatchEndIndex, m.Index - lastMatchEndIndex);
                // 执行第一次进入这个循环时，不会执行这个方法
                // 因为第一个 eager execution block 执行块肯定在文本的开头
                ParseFlowChartNodeText(flowChartNodeText);
                lastMatchEndIndex = m.Index + m.Length;

                string eagerExecutionBlockCode = m.Groups[1].Value;
                // Debug.LogFormat("Eager code: <color=blue><b>{0}</b></color>", eagerExecutionBlockCode);
                DoEagerExecutionBlock(eagerExecutionBlockCode);
            }

            // 一个脚本文件应该以一个 eager execution block 结束
            // 最后一个 eager execution block 之后的所有内容都将被忽略
            if (lastMatchEndIndex < text.Length)
            {
                Debug.LogWarning("Anita: A script file should ends with a eager execution block, " +
                                 "which needs to refer to the next flow chart node.");
            }
        }

        // 这个方法的名字可能有点误导，因为这个方法实际上解析文本由 eager execution块分割
        // 而节点结构由 eager execution 中的脚本定义
        // 当在 eager execution 块中调用' label' 指令时会创建一个新节点，并且它的
        /// 当“branch”或“jump”指令被调用时，内容结束。当前实施用状态机构造流程图树，即将解析的流程图节点文本推送到当前节点。
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

        // 绑定所有节点流向关系
        private void BindAllLazyBindingEntries()
        {
            foreach (var entry in lazyBindingLinks)
            {
                var node = entry.from;
                node.AddBranch(entry.branchInfo, flowChartTree.GetNode(entry.destination));
            }
            
            lazyBindingLinks = null;
        }

        // 在 eager execution blockCode中执行代码
        private static void DoEagerExecutionBlock(string eagerExecutionBlockCode)
        {
            LuaRuntime.Instance.DoString(eagerExecutionBlockCode);
        }

        #region Methods called by external scripts

        // 创建一个新的流程图节点，将其注册到当前正在构建的 FlowChartTree。
        // 如果当前节点是普通节点，则新创建的节点是它的后继节点。新节点和当前节点之间的链接将立即添加，即不会被绑定节点流向。
        // 此方法设计为由脚本在外部调用。
        public void RegisterNewNode(string name)
        {
            var nextNode = new FlowChartNode(name);
            if (currentNode != null && currentNode.type == FlowChartNodeType.Normal)
            {
                currentNode.AddBranch(BranchInformation.Default, nextNode);
            }

            currentNode = nextNode;

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
        
        /// 注册一个跳转链接并将当前节点设为空。
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

        // 将分支添加到当前节点。
        // 当前节点的类型将切换为分支。
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
        
        // 停止将分支注册到当前节点，并将当前节点设为空。
        public void EndRegisterBranch()
        {
            currentNode = null;
        }

        // 将当前节点设置为开始节点。
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

        // 将当前节点设置为默认 start。
        public void SetCurrentAsDefaultStart(string name)
        {
            SetCurrentAsUnlockedStart(name);
            flowChartTree.defaultStartNode = currentNode;
        }

        // 将当前节点设置为默认 end
        // 一个流程树可能有多个 end
        // 每个 end 的 name 应该是全局唯一的
        public void SetCurrentAsEnd(string name)
        {
            if (currentNode == null)
            {
                throw new ArgumentException(
                    $"Anita: SetCurrentAsEnd({name}) should be called after registering the current node.");
            }

            // currentNode 设为 end
            currentNode.type = FlowChartNodeType.End;

            if (name == null)
            {
                name = currentNode.name;
            }

            flowChartTree.AddEnd(name, currentNode);

            // 当前节点为Null，因为SetCurrentAsEnd（）表示节点的结束
            currentNode = null;
        }

        #endregion
    }
}