using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Undirected_Graph
{
    public class Edge
    {
        public Node From { get; set; }
        public Node To { get; set; }
        public int Weight { get; set; }

        public Edge(Node from, Node to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{From.ToString()} -> {To.ToString()}";
        }
    }
}
