using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Trie
{
    public class TriesUsingArray
    {
        private class Node
        {
            public Node(char c)
            {
                Value = c;
            }
            public char Value { get; set; }
            public Node[] ChildNodes { get; set; } = new Node[26];
            public bool IsEndOfWord { get; set; }
        }

        private Node Root { get; set; }

        public TriesUsingArray()
        {
            Root = new Node(default(char));
        }

        public void Insert(string val)
        {
            var current = Root;
            foreach(var c in val.ToCharArray())
            {
                var index = c - 'a';
                if (current.ChildNodes[index] == null)
                    current.ChildNodes[index] = new Node(c);
                current = current.ChildNodes[index];
            }
            current.IsEndOfWord = true;
        }
    }
}
