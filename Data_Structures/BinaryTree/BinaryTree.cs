using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.BinaryTree
{
    public class BinaryTree
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
    }
}
