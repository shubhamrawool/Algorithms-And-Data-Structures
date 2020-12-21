using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures.Undirected_Graph
{
    public class UndirectedGraph
    {
        private Dictionary<string, Node> Vertices;

        public UndirectedGraph()
        {
            Vertices = new Dictionary<string, Node>();
        }

        #region Graph Operations
        public void AddNode(string label)
        {
            if (!Vertices.ContainsKey(label))
            {
                Vertices.Add(label, new Node(label));
            }
        }

        public void AddEdge(string from, string to, int weight)
        {
            var fromNode = Vertices[from];
            var toNode = Vertices[to];
            if (fromNode == null || toNode == null)
            {
                throw new ArgumentNullException();
            }
            fromNode.AddEdge(toNode, weight); ;
            toNode.AddEdge(fromNode, weight);
        }

        public bool ContainsNode(string label)
        {
            return Vertices.ContainsKey(label);
        }

        public void Print()
        {
            foreach (var node in Vertices.Values)
            {
                if (node.Edges.Count > 0)
                {
                    foreach (var edge in node.Edges)
                    {
                        Console.WriteLine($" Node { edge.From.ToString() } is connected to { edge.ToString() }");
                    }
                }
            }
        }

        #endregion

        #region Dijkstra's Algorithm
        public Path GetShortestDistance(string from, string to)
        {
            var fromNode = Vertices.GetValueOrDefault(from);
            var toNode = Vertices.GetValueOrDefault(to);
            if (fromNode == null || toNode == null)
                throw new ArgumentNullException();

            var sortedSet = new CustomPriorityQueueForDjikshra();
            sortedSet.Push(new NodeEntry(fromNode, 0));

            var nodeDistance = new Dictionary<Node, int>();
            var previousNode = new Dictionary<Node, Node>();
            foreach (var node in Vertices.Values)
            {
                nodeDistance.Add(node, int.MaxValue);
                previousNode.Add(node, null);
            }
            nodeDistance[fromNode] = 0;

            var visitedNodes = new HashSet<Node>();

            while (sortedSet.Count != 0)
            {
                var node = sortedSet.Pop();
                foreach (var n in node.Node.Edges)
                {
                    if (!visitedNodes.Contains(n.To))
                    {
                        var weight = FindTotalWeight(node.Node, n.To, previousNode, nodeDistance);
                        if (nodeDistance[n.To] > weight)
                        {
                            nodeDistance[n.To] = weight;
                            previousNode[n.To] = node.Node;
                            sortedSet.Push(new NodeEntry(n.To, weight));
                        }
                    }
                }
                visitedNodes.Add(node.Node);
            }
            return BuildShortestPath(toNode, previousNode);
        }

        private Path BuildShortestPath(Node finalNode, Dictionary<Node, Node> previousNode)
        {
            var stack = new Stack<Node>();
            var pNode = finalNode;
            while (pNode != null)
            {
                stack.Push(pNode);
                pNode = previousNode[pNode];
            }

            var path = new Path();
            while (stack.Count != 0)
                path.AddNode(stack.Pop().Label);
            return path;
        }

        private int FindTotalWeight(Node currentNode, Node childNode, Dictionary<Node, Node> previousNode, Dictionary<Node, int> nodeDistance)
        {
            var weight = currentNode.Edges.Find(x => x.To == childNode).Weight;
            weight = weight + nodeDistance[currentNode];
            return weight;
        }
        #endregion

        #region Cycle Detection
        public bool HasCycles()
        {
            var visitedNodes = new HashSet<Node>();
            foreach (var node in Vertices.Values)
            {
                if (!visitedNodes.Contains(node) && DetectCycles(null, node, visitedNodes))
                    return true;
            }
            return false;
        }

        private bool DetectCycles(Node parentNode, Node node, HashSet<Node> visitedNodes)
        {
            visitedNodes.Add(node);
            foreach (var edge in node.GetEdges())
            {
                var childNode = edge.To;
                if (parentNode == childNode)
                    continue;

                if (visitedNodes.Contains(childNode) || DetectCycles(node, childNode, visitedNodes))
                    return true;

            }
            return false;
        }
        #endregion

        #region Minimum Spanning Tree using Prim's algorith

        public UndirectedGraph FindMinimumSpanningTree()
        {
            var tree = new UndirectedGraph();
            var priorityQueue = new CustomPriotiryQueueForPrim();

            var startNode = Vertices.Values.First();
            startNode.Edges.ForEach(edge => priorityQueue.Push(edge));

            tree.AddNode(startNode.Label);

            while (tree.Vertices.Count < Vertices.Count)
            {
                var minimumWeightEdge = priorityQueue.Pop();
                var nextNode = minimumWeightEdge.To;
                if (tree.ContainsNode(nextNode.Label))
                    continue;

                tree.AddNode(nextNode.Label);
                tree.AddEdge(minimumWeightEdge.From.Label, nextNode.Label, minimumWeightEdge.Weight);

                nextNode.Edges.ForEach(edge =>
                {
                    if (!tree.ContainsNode(edge.To.Label))
                    {
                        priorityQueue.Push(edge);
                    }
                });
            }
            return tree;
        }

        /// <summary>
        /// Recursive Implementation For Prim
        /// </summary>
        /// <param name="node"></param>
        /// <param name="spanningTree"></param>
        /// <param name="visited"></param>
        /// <param name="priotiryQueueForPrim"></param>
        /// <param name="path"></param>
        private void FindMinimumSpanningTree(Node node, UndirectedGraph spanningTree, HashSet<Node> visited, CustomPriotiryQueueForPrim priotiryQueueForPrim, Path path)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                path.AddNode(node.Label);
                foreach (var edge in node.Edges)
                    priotiryQueueForPrim.Push(edge);
                Edge edgeToVisit = null;
                while (edgeToVisit == null && priotiryQueueForPrim.Count() > 0)
                {
                    var minimumPriorityEdge = priotiryQueueForPrim.Pop();
                    if (!visited.Contains(minimumPriorityEdge.To))
                    {
                        edgeToVisit = minimumPriorityEdge;
                        spanningTree.AddNode(edgeToVisit.From.Label);
                        spanningTree.AddNode(edgeToVisit.To.Label);
                        spanningTree.AddEdge(edgeToVisit.From.Label, edgeToVisit.To.Label, edgeToVisit.Weight);
                    }
                }
                if (edgeToVisit != null)
                {
                    FindMinimumSpanningTree(edgeToVisit.To, spanningTree, visited, priotiryQueueForPrim, path);
                }
            }
        }

        #endregion
    }
}
