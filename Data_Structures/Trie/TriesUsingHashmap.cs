using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Trie
{
    public class TriesUsingHashmap
    {
        private class Node
        {
            public char Value { get; set; }
            public Dictionary<char, Node> ChildNodes { get; set; }
            public bool IsEndOfWord { get; set; }
            public Node(char val)
            {
                Value = val;
                ChildNodes = new Dictionary<char, Node>();
            }

            public bool HasChild(char c)
            {
                return ChildNodes.ContainsKey(c);
            }

            public void AddChild(char c)
            {
                ChildNodes.Add(c, new Node(c));
            }

            public Node GetChildNode(char c)
            {
                return ChildNodes[c];
            }

            public Node[] GetAllChildren()
            {
                var nodeArray = new Node[ChildNodes.Count];
                ChildNodes.Values.CopyTo(nodeArray, 0);
                return nodeArray;
            }

            public bool HasChildren()
            {
                return ChildNodes.Count > 0;
            }

            internal void RemoveChildNode(Node child)
            {
                ChildNodes.Remove(child.Value);
            }
        }

        private Node Root { get; set; }

        public TriesUsingHashmap()
        {
            Root = new Node(default(char));
        }

        public void Insert(string val)
        {
            var current = Root;
            foreach (char c in val.ToCharArray())
            {
                if (!current.HasChild(c))
                    current.AddChild(c);
                current = current.GetChildNode(c);
            }
            current.IsEndOfWord = true;
        }

        public bool Contains(string val)
        {
            if (string.IsNullOrEmpty(val))
                return false;

            var current = Root;
            foreach (var c in val.ToCharArray())
            {
                if (!current.HasChild(c))
                    return false;
                current = current.GetChildNode(c);
            }
            return current.IsEndOfWord;
        }

        public void Traverse()
        {
            Traverse(Root);
        }

        private void Traverse(Node node)
        {
            Console.WriteLine(node.Value);

            foreach (var n in node.GetAllChildren())
            {
                Traverse(n);
            }
        }

        public void Remove(string val)
        {
            if (val == null)
            {
                return;
            }
            Remove(Root, val, 0);
        }

        //private void Remove(Node parentNode,Node node, string str)
        //{
        //    var charToRemove = str.Length > 0 ? str.ToCharArray()[0].ToString() : string.Empty;
        //    if(!string.IsNullOrEmpty(charToRemove))
        //    {
        //        Remove(node ,node.GetChildNode(charToRemove.ToCharArray()[0]), str.Remove(0,1));
        //    } 
        //    else
        //    {
        //        node.IsEndOfWord = false;
        //    }
        //    if(!node.IsEndOfWord && node.GetAllChildren().Length == 0 && parentNode != null)
        //    {
        //        parentNode.ChildNodes.Remove(node.Value);
        //    }

        //}

        private void Remove(Node node, string str, int index)
        {
            if (str.Length == index)
            {
                node.IsEndOfWord = false;
                return;
            }
            var charToRemove = str[index];
            var child = node.GetChildNode(charToRemove);
            if (child == null)
            {
                return;
            }

            Remove(child, str, index + 1);

            if (!child.IsEndOfWord && !child.HasChildren())
            {
                node.RemoveChildNode(child);
            }
        }

        public List<string> AutoComplete(string str)
        {
            var lastNode = FindLastNode(str);
            var wordList = new List<string>();
            if (lastNode == null)
                return new List<string>();
            AutoComplete(lastNode, str, wordList);
            return wordList;
        }

        private void AutoComplete(Node node, string str, List<string> wordList)
        {
            if (node == null)
                return;
            if (node.IsEndOfWord == true)
            {
                wordList.Add(str);
            }
            foreach (var n in node.GetAllChildren())
            {
                AutoComplete(n, str + n.Value.ToString(), wordList);

            }
        }

        private Node FindLastNode(string str)
        {
            if (str == null)
                return null;
            var current = Root;
            foreach (var c in str)
            {
                var childNode = current.GetChildNode(c);
                if (childNode == null)
                    return null;
                current = childNode;
            }
            return current;
        }
    }
}
