using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Undirected_Graph
{
    public class Path
    {
        private List<string> nodes = new List<string>();

        public void AddNode(string node)
        {
            nodes.Add(node);
        }

        public override string ToString()
        {
            var nodeList = new StringBuilder("");
            nodes.ForEach(node =>
            {
                nodeList.Append(node);
                if (node != nodes[nodes.Count - 1])
                    nodeList.Append(" -> ");
            });
            return nodeList.ToString();
        }
    }
}
