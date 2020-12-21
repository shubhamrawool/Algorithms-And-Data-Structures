using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Undirected_Graph
{
    public class NodeEntry
    {
        public Node Node { get; set; }
        public int Priority { get; set; }
        public NodeEntry(Node node, int priority)
        {
            Node = node;
            Priority = priority;
        }
    }
}
