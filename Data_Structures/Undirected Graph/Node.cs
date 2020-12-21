using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Undirected_Graph
{
    public class Node
    {
        public string Label { get; set; }
        public List<Edge> Edges { get; set; }

        public Node(string label)
        {
            Label = label;
            Edges = new List<Edge>();
        }

        public void AddEdge(Node to, int weight)
        {
            Edges.Add(new Edge(this, to, weight));
        }

        public List<Edge> GetEdges()
        {
            return Edges;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}
