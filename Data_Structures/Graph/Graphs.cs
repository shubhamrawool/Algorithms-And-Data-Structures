using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Graph
{
    public class Graphs
    {
        private class Node
        {
            public Node(string label)
            {
                Label = label;
            }
            public string Label { get; set; }

            public override string ToString()
            {
                return Label;
            }
        }

        private Dictionary<string, Node> Vertices = new Dictionary<string, Node>();

        private Dictionary<Node, LinkedList<Node>> AdjacencyList = new Dictionary<Node, LinkedList<Node>>();

        public void AddNode(string label)
        {
            var node = new Node(label);
            if (!Vertices.ContainsKey(label))
            {
                Vertices.Add(label, node);
                AdjacencyList.Add(node, new LinkedList<Node>());
            }
        }

        public void AddEdge(string from, string to)
        {
            var sourceNode = Vertices[from];
            var toNode = Vertices[to];
            if (sourceNode == null || toNode == null)
            {
                throw new ArgumentNullException();
            }
            AdjacencyList[sourceNode].AddLast(toNode);
        }

        public void RemoveNode(string label)
        {
            if (Vertices.ContainsKey(label))
            {
                var node = Vertices[label];
                foreach (var vertex in AdjacencyList)
                {
                    if (vertex.Value.Contains(node))
                    {
                        vertex.Value.Remove(node);
                    }
                }

                AdjacencyList.Remove(node);
                Vertices.Remove(label);
            }
        }

        public void RemoveEdge(string from, string to)
        {
            var sourceNode = Vertices[from];
            var targetNode = Vertices[to];
            if (sourceNode == null || targetNode == null)
            {
                throw new ArgumentNullException();
            }
            var list = AdjacencyList[Vertices[from]];
            list.Remove(targetNode);
        }


        public void RecursiveDepthFirstTraversal(string label)
        {
            var visitedNodes = new HashSet<Node>();
            var startNode = Vertices[label];
            if (startNode != null)
                RecursiveDepthFirstTraversal(startNode, visitedNodes);
        }

        private void RecursiveDepthFirstTraversal(Node node, HashSet<Node> visitedNodes)
        {
            Console.WriteLine(node.ToString());
            visitedNodes.Add(node);

            var connectedNodesList = AdjacencyList[node];
            foreach (var connectedNode in connectedNodesList)
            {
                if (!visitedNodes.Contains(connectedNode))
                {
                    RecursiveDepthFirstTraversal(connectedNode, visitedNodes);
                }
            }
        }

        public void IterativeDepthFirstTraversal(string label)
        {
            var rootNode = Vertices[label];
            if (rootNode == null)
                return;

            var visitedNodes = new HashSet<Node>();
            var nodeStack = new Stack<Node>();
            nodeStack.Push(rootNode);

            while (nodeStack.Count != 0)
            {
                var currentNode = nodeStack.Pop();

                if (visitedNodes.Contains(currentNode))
                    continue;

                Console.WriteLine(currentNode.Label);
                visitedNodes.Add(currentNode);
                foreach (var node in AdjacencyList[currentNode])
                {
                    if (!visitedNodes.Contains(node))
                        nodeStack.Push(node);

                }
            }
        }

        public void BreadthFirstTraversal(string label)
        {
            var rootNode = Vertices[label];
            if (rootNode == null)
                return;
            var nodeQueue = new Queue<Node>();
            var visitedNodes = new HashSet<Node>();

            nodeQueue.Enqueue(rootNode);
            while (nodeQueue.Count != 0)
            {
                var currentNode = nodeQueue.Dequeue();
                visitedNodes.Add(currentNode);
                Console.WriteLine(currentNode.Label);

                foreach (var node in AdjacencyList[currentNode])
                {
                    if (!visitedNodes.Contains(node))
                        nodeQueue.Enqueue(node);
                }
            }
        }

        public List<string> TopologicalSort()
        {
            var nodeOrderStack = new Stack<Node>();
            var visitedNodes = new HashSet<Node>();
            foreach (var node in Vertices.Values)
            {
                TopologicalSort(node, visitedNodes, nodeOrderStack);
            }

            var sortedList = new List<string>();
            while (nodeOrderStack.Count != 0)
            {
                sortedList.Add(nodeOrderStack.Pop().Label);
            }
            return sortedList;
        }

        private void TopologicalSort(Node node, HashSet<Node> visitedNodes, Stack<Node> nodeOrderStack)
        {
            if (visitedNodes.Contains(node))
                return;
            visitedNodes.Add(node);
            foreach (var childNodes in AdjacencyList[node])
            {
                if (!visitedNodes.Contains(childNodes))
                    TopologicalSort(childNodes, visitedNodes, nodeOrderStack);
            }

            nodeOrderStack.Push(node);
        }

        public bool IsCyclePresent()
        {
            var allNodes = new List<Node>(Vertices.Values);
            var visitingNodes = new HashSet<Node>();
            var visitedNodes = new HashSet<Node>();

            while(allNodes.Count != 0)
            {
                var currentNode = allNodes[0];
                if (IsCyclePresent(currentNode, allNodes, visitingNodes, visitedNodes))
                    return true;
            }

            return false;
        }

        private bool IsCyclePresent(Node node, List<Node> allNodes, HashSet<Node> visitingNodes, HashSet<Node> visitedNodes)
        {
            allNodes.Remove(node);
            visitingNodes.Add(node);

            foreach(var childNode in AdjacencyList[node])
            {
                if (visitedNodes.Contains(childNode))
                    continue;

                if (visitingNodes.Contains(childNode))
                    return true;

                if (IsCyclePresent(childNode, allNodes, visitingNodes, visitedNodes))
                    return true;
            }

            visitingNodes.Remove(node);
            visitedNodes.Add(node);
            return false;
        }

        public void Print()
        {
            foreach (var node in AdjacencyList)
            {
                if (node.Value.Count > 0)
                {
                    foreach (var edge in node.Value)
                    {
                        Console.WriteLine($" Node { node.Key.ToString() } is connected to { edge.ToString() }");
                    }
                }
            }
        }
    }
}
