using System;
using System.Collections.Generic;
using System.IO;

namespace Data_Structures.BinaryTree
{
    public class BinaryTrees
    {
        private class Node
        {
            public Node(int value)
            {
                Value = value;
            }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
            public int Value { get; set; }
        }
        private Node Root;

        public void Insert(int value)
        {
            var node = new Node(value);
            if (Root == null)
            {
                Root = node;
                return;
            }
            var currentNode = Root;
            while (true)
            {
                if (value < currentNode.Value)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = node;
                        break;
                    }
                    currentNode = currentNode.LeftChild;
                }
                else if (value > currentNode.Value)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = node;
                        break;
                    }
                    currentNode = currentNode.RightChild;
                }
            }
        }

        public bool Find(int value)
        {
            if (Root == null) return false;
            var currentNode = Root;
            while (currentNode != null)
            {
                if (currentNode.Value > value)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value < value)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                    return true;
            }
            return false;
        }

        public void TraverseTreePreOrder()
        {
            TraverseTreePreOrder(Root);
        }

        private void TraverseTreePreOrder(Node root)
        {
            if (root == null) return;
            Console.WriteLine(root.Value);
            TraverseTreePreOrder(root.LeftChild);
            TraverseTreePreOrder(root.RightChild);
        }

        public void TraverseTreeInOrder()
        {
            TraverseTreeInOrder(Root);
        }

        private void TraverseTreeInOrder(Node root)
        {
            if (root == null) return;
            TraverseTreeInOrder(root.LeftChild);
            Console.WriteLine(root.Value);
            TraverseTreeInOrder(root.RightChild);
        }

        public void TraverseTreePostOrder()
        {
            TraverseTreePostOrder(Root);
        }

        private void TraverseTreePostOrder(Node root)
        {
            if (root == null) return;
            TraverseTreePostOrder(root.LeftChild);
            TraverseTreePostOrder(root.RightChild);
            Console.WriteLine(root.Value);
        }

        public int TreeHeight()
        {
            if (Root == null) return -1;
            return TreeHeight(Root);
        }

        private int TreeHeight(Node node)
        {
            if (IsLeafNode(node)) return 0;
            return 1 + Math.Max(TreeHeight(node.LeftChild), TreeHeight(node.RightChild));
        }

        public int MinimumValueBinarySearchTree()
        {
            if (Root == null) return -1;
            var current = Root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.LeftChild;
            }
            return last.Value;
        }

        public int MinimumValueBinaryTree()
        {
            if (Root == null) return -1;
            return MinimumValueBinaryTree(Root);
        }

        private int MinimumValueBinaryTree(Node root)
        {
            if (IsLeafNode(root)) return root.Value;

            var left = MinimumValueBinaryTree(root.LeftChild);
            var right = MinimumValueBinaryTree(root.RightChild);

            return Math.Min(root.Value, Math.Min(left, right));
        }

        public bool IsEqual(BinaryTrees targetTree)
        {
            if (Root == null || targetTree == null || targetTree.Root == null) return false;
            return TreeNodesComparer(Root, targetTree.Root);
        }

        private bool TreeNodesComparer(Node srcNode, Node targetNode)
        {
            if (srcNode == null && targetNode == null) return true;
            if (srcNode != null && targetNode != null)
                return srcNode.Value == targetNode.Value &&
                    TreeNodesComparer(srcNode.LeftChild, targetNode.LeftChild) &&
                    TreeNodesComparer(srcNode.RightChild, targetNode.RightChild);
            return false;
        }

        public bool IsBinarySearchTree()
        {
            if (Root == null) return true;
            return IsBinarySearchTree(Root, -(int.MaxValue), int.MaxValue);
        }

        private bool IsBinarySearchTree(Node node, int minVal, int maxVal)
        {
            if (node == null) return true;
            if (node.Value < minVal || node.Value > maxVal)
                return false;
            return IsBinarySearchTree(node.LeftChild, minVal, node.Value - 1) && IsBinarySearchTree(node.RightChild, node.Value + 1, maxVal);
        }

        public List<int> GetNodesAtKDistance(int distance)
        {
            var list = new List<int>();
            if (distance < 0) throw new InvalidDataException("Distance must be greater that 0.");
            if (Root == null) throw new InvalidDataException("Empty Binary Tree");
            GetNodesAtKDistance(Root, distance, list);
            return list;
        }

        private void GetNodesAtKDistance(Node node, int distance, List<int> list)
        {
            if (distance == 0) { list.Add(node.Value); return; }
            if (IsLeafNode(node)) return;
            GetNodesAtKDistance(node.LeftChild, distance - 1, list);
            GetNodesAtKDistance(node.RightChild, distance - 1, list);
        }

        public void LevelOrderTraversal()
        {
            for(var i=0; i <= TreeHeight(); i++)
            {
                GetNodesAtKDistance(i).ForEach(x => Console.WriteLine(x));
            }
        }

        private bool IsLeafNode(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }
    }
}
