using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.AVLTrees
{
    public class AVLTree
    {
        private class AVLNode
        {
            public int value { get; set; }
            public int height { get; set; }
            public AVLNode LeftChild { get; set; }
            public AVLNode RightChild { get; set; }
            public AVLNode(int value)
            {
                this.value = value;
            }
        }
        private AVLNode Root;

        public void Insert(int val)
        {
            Root = Insert(Root, val);
        }

        private AVLNode Insert(AVLNode node, int value)
        {
            if (node == null)
                return new AVLNode(value);
            if (value < node.value)
            {
                node.LeftChild = Insert(node.LeftChild, value);
            }
            else if (value > node.value)
            {
                node.RightChild = Insert(node.RightChild, value);
            }
            SetHeight(node);
            return Balance(node);
        }

        private AVLNode Balance(AVLNode node)
        {
            if (IsLeftHeavy(node))
            {
                if (BalanceFactor(node.LeftChild) < 0)
                    node.LeftChild = LeftRotate(node.LeftChild);  //Console.WriteLine(node.LeftChild.value + "Left Rotation");
                return RightRotate(node); //Console.WriteLine(node.value + "Right Rotation");
            }
            else if (IsRightHeavy(node))
            {
                if (BalanceFactor(node.RightChild) > 0)
                    node.RightChild = RightRotate(node.RightChild); //Console.WriteLine(node.RightChild.value + "Right Rotation");
                return LeftRotate(node); //Console.WriteLine(node.value + "Left Rotation");
            }
            return node;
        }

        private AVLNode LeftRotate(AVLNode node)
        {
            var newRoot = node.RightChild;
            node.RightChild = null;

            node.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = node;
            
            SetHeight(newRoot);
            SetHeight(node);
            
            return newRoot;
        }

        private AVLNode RightRotate(AVLNode node)
        {
            var newRoot = node.LeftChild;
            node.LeftChild = null;
            node.LeftChild = newRoot.RightChild;
            newRoot.RightChild = node;
            return newRoot;
        }

        private void SetHeight(AVLNode node)
        {
            node.height = Math.Max(Height(node.LeftChild), Height(node.RightChild)) + 1;
        }

        private bool IsLeftHeavy(AVLNode node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(AVLNode node)
        {
            return BalanceFactor(node) < -1;
        }

        private int BalanceFactor(AVLNode node)
        {
            return node == null ? 0 : (Height(node.LeftChild) - Height(node.RightChild));
        }

        private int Height(AVLNode node)
        {
            return node == null ? -1 : node.height;
        }
    }
}
