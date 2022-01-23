/*
 * 流程树 flow chart tree
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Anita.Exceptions;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anita
{
    // flow chart tree
    // 一个定义良好的流程图树应该至少有一个开始节点，所有没有子节点的节点都标记为结束节点。
    // 流程图树中的所有内容在冻结后都无法修改
    public class FlowChartTree
    {
        private readonly Dictionary<string, FlowChartNode> nodes = new Dictionary<string, FlowChartNode>();
        private readonly Dictionary<string, FlowChartNode> startNodes = new Dictionary<string, FlowChartNode>();
        private readonly Dictionary<string, FlowChartNode> unlockedStartNodes = new Dictionary<string, FlowChartNode>();
        private readonly Dictionary<FlowChartNode, string> endNodes = new Dictionary<FlowChartNode, string>();

        private bool isFrozen = false;

        // freeze 所有 node, flow chart tree 构建完成后调用
        public void Freeze()
        {
            isFrozen = true;
            foreach (var node in nodes.Values)
            {
                node.Freeze();
            }
        }

        private void CheckFreeze()
        {
            Assert.IsFalse(isFrozen, "Anita: Cannot modify a flow chart tree when it is frozen.");
        }

        // 给 flow chat tree 添加一个 node
        public void AddNode(FlowChartNode node)
        {
            CheckFreeze();
            var name = node.name;
            nodes.Add(name, node);
        }
        
        // 通过 name 返回node
        public FlowChartNode GetNode(string name)
        {
            nodes.TryGetValue(name, out var node);
            return node;
        }

        // 检查是否 tree 已包含同 name 的 node
        public bool HasNode(string name)
        {
            return nodes.ContainsKey(name);
        }

        // 检查 tree 是否已包含该 node
        public bool HasNode(FlowChartNode node)
        {
            return nodes.ContainsKey(node.name);
        }

        // 返回所有 start name
        public List<string> GetAllStartNodeNames()
        {
            return startNodes.Keys.ToList();
        }

        public List<string> GetAllUnlockedStartNodeNames()
        {
            return unlockedStartNodes.Keys.ToList();
        }

        // 添加一个 node 
        // 可以将 name 分配给 node，该 name 可以不同于 node 名称。
        // name 在所有 start 名称中应该是唯一的。
        // 此方法将检查给定 name 是否不在 tree 中，以及给定 name 是否已经在 tree 中。
        public void AddStart(string name, FlowChartNode node)
        {
            CheckFreeze();

            if (!HasNode(node))
            {
                throw new ArgumentException("Anita: Only node in the tree can be set as a start node.");
            }

            var existingStartNode = GetStartNode(name);
            if (existingStartNode != null && !existingStartNode.Equals(node))
            {
                throw new DuplicatedDefinitionException(
                    $"Anita: Duplicated definition of the same start name: {name}");
            }

            startNodes.Add(name, node);
            Debug.Log($"Anita_tree_add_node : {name} ");
        }

        public void AddUnlockedStart(string name, FlowChartNode node)
        {
            unlockedStartNodes.Add(name, node);
        }

        // 通过 name 取得一个 start name
        public FlowChartNode GetStartNode(string name)
        {
            startNodes.TryGetValue(name, out var node);
            return node;
        }
        
        public bool HasStart(string name)
        {
            return startNodes.ContainsKey(name);
        }

        private FlowChartNode _defaultStartNode;

        // default start node 
        /// 取值时，如果已设置 default start node ，则返回赋值。
        /// 否则，检查起始节点字典。如果至少有一个 start node ，则返回第一个。
        /// 否则，返回null。
        public FlowChartNode defaultStartNode
        {
            get
            {
                if (_defaultStartNode != null)
                {
                    return _defaultStartNode;
                }

                return startNodes.Values.FirstOrDefault();
            }
            set
            {
                CheckFreeze();

                if (_defaultStartNode == null)
                {
                    _defaultStartNode = value;
                }

                if (!_defaultStartNode.Equals(value))
                {
                    throw new ArgumentException("Anita: Only one node can be the default start point.");
                }
            }
        }

        public void AddEnd(string name, FlowChartNode node)
        {
            CheckFreeze();

            if (!HasNode(node))
            {
                throw new ArgumentException("Anita: Only node in the tree can be set as an end node.");
            }

            var existingNodeName = GetEndName(node);
            if (existingNodeName == null)
            {
                // node 还没被定义为 end
                if (endNodes.ContainsValue(name))
                {
                    // 但是 name 已经被使用了
                    throw new DuplicatedDefinitionException(
                        $"Anita: Duplicated definition of the same end name: {name}");
                }

                // name 是唯一的， 添加该 node 作为 end
                endNodes.Add(node, name);
                return;
            }

            // 该 node 已经作为 end 了 
            if (existingNodeName != name)
            {
                // 但是作为 name 的 end node 是不同的
                throw new DuplicatedDefinitionException(
                    $"Anita: Assigning two different end name: {existingNodeName} and {name} to the same node.");
            }
        }

        // 通过 name 返回一个 end node
        public string GetEndName(FlowChartNode node)
        {
            return endNodes.TryGetValue(node, out var name) ? name : null;
        }

        // 检查 tree 是否含有给定 name 的 end
        public bool HasEnd(string name)
        {
            return endNodes.ContainsValue(name);
        }
        
        // 对流程图树执行健全性检查
        // 健全性检查包括：
        // + tree 至少有一个 start node；
        // + 所有没有子节点的 node 都被标记为 end node
        // + 该方法应在 flow chart tee 构建完成后调用。
        public void SanityCheck()
        {
            CheckFreeze();

            if (startNodes.Count == 0)
            {
                throw new ArgumentException("Anita: At least one start node should exist.");
            }

            foreach (var node in nodes.Values)
            {
                if (node.branchCount == 0 && node.type != FlowChartNodeType.End)
                {
                    Debug.LogWarningFormat(
                        "Anita: Node {0} has no child. It will be marked as an end with name {0}.",
                        node.name);
                    node.type = FlowChartNodeType.End;
                    AddEnd(node.name, node);
                }
            }
        }
    }
}