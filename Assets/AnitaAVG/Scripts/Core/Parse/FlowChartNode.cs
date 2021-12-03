/*
 * 流程图的节点
 * 每个节点：
 * {
 *      List[DialogueEntris]   // n条对话
 *      Dic<BranchInformation, FlowChartNode> // n个分支，及对应流向的节点 
 * }
 */

using Anita.Exceptions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anita
{
    public enum FlowChartNodeType
    {
        Normal,
        Branching,
        End
    }

    // 流程图上的一个节点
    // 节点在frozen后不可修改
    public class FlowChartNode
    {
        /// Localized后的name存储在I18nHelper.NodeNames
        public readonly string name;

        public FlowChartNode(string name)
        {
            this.name = name;
        }

        private bool isFrozen = false;

        // freeze 该节点
        public void Freeze()
        {
            isFrozen = true;
        }

        private void CheckFreeze()
        {
            Assert.IsFalse(isFrozen, "Anita: Cannot modify a flow chart node when it is frozen.");
        }

        private FlowChartNodeType _type = FlowChartNodeType.Normal;

        // 此流程图节点的类型。该字段的值默认为normal
        // 流程图树在构建后应freeze其所有节点。
        public FlowChartNodeType type
        {
            get => _type;
            set
            {
                CheckFreeze();
                _type = value;
            }
        }

        
        // 节点中的Dialogue
        #region Dialogue entries
        
        private List<DialogueEntry> dialogueEntries = new List<DialogueEntry>();

        public int dialogueEntryCount => dialogueEntries.Count;

        public void SetDialogueEntries(List<DialogueEntry> entries)
        {
            dialogueEntries = entries;
        }

        public void AddLocaleForDialogueEntries(SystemLanguage locale, IReadOnlyList<LocalizedDialogueEntry> entries)
        {
            Assert.IsTrue(entries.Count == dialogueEntries.Count, "Anita: Localized dialogue entry count differs.");

            for (int i = 0; i < entries.Count; ++i)
            {
                dialogueEntries[i].AddLocale(locale, entries[i]);
            }
        }

        // 获取对应索引的dialogue
        public DialogueEntry GetDialogueEntryAt(int index)
        {
            return dialogueEntries[index];
        }

        #endregion

        // 分支
        #region Branches
        
        private readonly Dictionary<BranchInformation, FlowChartNode> branches =
            new Dictionary<BranchInformation, FlowChartNode>();
        
        public int branchCount => branches.Count;

        // 获取普通节点的下一个节点。只有 Normal 节点可以调用
        public FlowChartNode next
        {
            get
            {
                if (type != FlowChartNodeType.Normal)
                {
                    throw new InvalidAccessException(
                        "Antia: Field Next of a flow chart node is only available when its type is Normal.");
                }

                return branches[BranchInformation.Default];
            }
        }

        // 向这个节点添加一个分支
        public void AddBranch(BranchInformation branchInformation, FlowChartNode nextNode)
        {
            CheckFreeze();
            branches.Add(branchInformation, nextNode);
        }

        // 返回所有分支
        public IEnumerable<BranchInformation> GetAllBranches()
        {
            return branches.Keys;
        }

        //通过 branchName 获取下一个 node 
        public FlowChartNode GetNext(string branchName)
        {
            return branches[new BranchInformation(branchName)];
        }

        #endregion

        // 通过 name 判断是否相等
        public override bool Equals(object obj)
        {
            return obj is FlowChartNode anotherObject && name.Equals(anotherObject.name);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}