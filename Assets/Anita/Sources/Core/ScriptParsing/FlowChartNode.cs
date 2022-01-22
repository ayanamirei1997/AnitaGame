/*
 * 流程节点
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

    // flow chart 的一个 node
    // 每个 node 为 frozen 时， node 内信息不可改变
    public class FlowChartNode
    {
        // flow chart node 的 name
        // 该 name 应该是唯一的
        // Localized names 存在 I18nHelper.NodeNames
        public readonly string name;

        public FlowChartNode(string name)
        {
            this.name = name;
        }

        private bool isFrozen = false;

        // freeze 当前node
        public void Freeze()
        {
            isFrozen = true;
        }
        
        private void CheckFreeze()
        {
            Assert.IsFalse(isFrozen, "Anita: Cannot modify a flow chart node when it is frozen.");
        }

        private FlowChartNodeType _type = FlowChartNodeType.Normal;
        
        // flow chart node 的 type, 默认的 type 为 normal
        // node 的 type 应该总是可读的， 但只在 frozen 前应先设置
        public FlowChartNodeType type
        {
            get => _type;
            set
            {
                CheckFreeze();
                _type = value;
            }
        }

        #region Dialogue entries

        // 当前 node 的Dialogue entries
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

        // 根据 index 获取对应的 dialogue entry
        public DialogueEntry GetDialogueEntryAt(int index)
        {
            return dialogueEntries[index];
        }

        #endregion

        #region Branches

        // the number of dialogue entries in this node
        private readonly Dictionary<BranchInformation, FlowChartNode> branches =
            new Dictionary<BranchInformation, FlowChartNode>();

        // branches 的数量
        public int branchCount => branches.Count;

        // 获取 normal node 的下一个 node。只有 normal 才能调用此属性
        public FlowChartNode next
        {
            get
            {
                if (type != FlowChartNodeType.Normal)
                {
                    throw new InvalidAccessException(
                        "Anita: Field Next of a flow chart node is only available when its type is Normal.");
                }

                return branches[BranchInformation.Default];
            }
        }

        // 添加一个 branch 到当前 node
        public void AddBranch(BranchInformation branchInformation, FlowChartNode nextNode)
        {
            CheckFreeze();
            branches.Add(branchInformation, nextNode);
        }

        // 获取当前 node 所有branch
        public IEnumerable<BranchInformation> GetAllBranches()
        {
            return branches.Keys;
        }

        // 通过 branch name 获得 next node
        public FlowChartNode GetNext(string branchName)
        {
            return branches[new BranchInformation(branchName)];
        }

        #endregion

        // 当且仅当 name 相同时，才认为两个 flow chat node 是相等的
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