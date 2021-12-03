/*
 * 整个游戏的流程树
 * 由各个 node 组成 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Anita.Exceptions;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anita
{
    // 存储所有流程节点的流程树
    // 整个流程应该至少有一个起始节点，所有没有子节点的节点都被标记为结束节点。
    public class FlowChartTree
    {
        private readonly Dictionary<string, FlowChartNode> nodes = new Dictionary<string, FlowChartNode>();
        private readonly Dictionary<string, FlowChartNode> startNodes = new Dictionary<string, FlowChartNode>();
        private readonly Dictionary<string, FlowChartNode> unlockedStartNodes = new Dictionary<string, FlowChartNode>();
        private readonly Dictionary<FlowChartNode, string> endNodes = new Dictionary<FlowChartNode, string>();

        private bool isFrozen = false;

        // freeze 所有的节点， 当整个流程树构建完成后， 子节点才可以调用
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

        // 给流程树添加一个节点
        public void AddNode(FlowChartNode node)
        {
            CheckFreeze();
            var name = node.name;
            nodes.Add(name, node);
        }

        // 通过 name 返回 node
        public FlowChartNode GetNode(string name)
        {
            nodes.TryGetValue(name, out var node);
            return node;
        }

        // 检查是否有该 node
        public bool HasNode(string name)
        {
            return nodes.ContainsKey(name);
        }

        public bool HasNode(FlowChartNode node)
        {
            return nodes.ContainsKey(node.name);
        }
        
        public List<string> GetAllStartNodeNames()
        {
            return startNodes.Keys.ToList();
        }

        public List<string> GetAllUnlockedStartNodeNames()
        {
            return unlockedStartNodes.Keys.ToList();
        }

        // 添加开始节点
        // 可以为起点指定一个名称，该名称可以与节点名称不同。
        // 此方法将检查给定的名称是否不在树中，并且给定的节点是否已经在树中。
        // 如果定义了相同的起点名称，则会抛出 DuplicatedDefinitionException
        // 如果节点不在树中，则会抛出 ArgumentException。
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
        }

        public void AddUnlockedStart(string name, FlowChartNode node)
        {
            unlockedStartNodes.Add(name, node);
        }
        
        // 通过 name 返回startNode
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

        // 默认的 startNode
        // 取值时，如果已经设置了默认的起始节点，则返回赋值的值。否则，检查起始节点dict。
        // 如果至少有一个起始节点，则返回第一个。否则，返回 null。
        // 设置该值时，将检查是否已设置默认起始节点。
        // 如果两个不同节点被设置为默认的 startNode 会返回 ArgumentException
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
                    throw new ArgumentException("Anita: one node can be the default start point.");
                }
            }
        }

        // 添加结束节点
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
                // 该节点未被设置为 endNode
                if (endNodes.ContainsValue(name))
                {
                    // 但该节点 name 被用过
                    throw new DuplicatedDefinitionException(
                        $"Anita: Duplicated definition of the same end name: {name}");
                }

                // name 是唯一的， 设置为 endNode
                endNodes.Add(node, name);
                return;
            }

            // 该节点已经被设置为 endNode
            if (existingNodeName != name)
            {
                // 要添加的和已存在的 endNode 的 name 不同
                throw new DuplicatedDefinitionException(
                    $"Anita: Assigning two different end name: {existingNodeName} and {name} to the same node.");
            }
        }

        // 返回 endNode 的 name
        public string GetEndName(FlowChartNode node)
        {
            return endNodes.TryGetValue(node, out var name) ? name : null;
        }

        // 含有 end
        public bool HasEnd(string name)
        {
            return endNodes.ContainsValue(name);
        }

        // 对流程树的健全性检查
        // 包含：
        // + 流程树至少一个 startNode
        // + 所有没有子节点的 node 都被视为 endNode
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