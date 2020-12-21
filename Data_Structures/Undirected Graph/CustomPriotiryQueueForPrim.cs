using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures.Undirected_Graph
{
    public class CustomPriotiryQueueForPrim
    {
        private List<Edge> edgeList;
        public CustomPriotiryQueueForPrim()
        {
            edgeList = new List<Edge>();
        }

        public void Push(Edge edge)
        {
            var existingEdge = edgeList.Find(x => x.From == edge.From && x.To == edge.To);
            if (existingEdge == null)
                edgeList.Add(edge);
            else
                existingEdge.Weight = edge.Weight;
            edgeList = edgeList.OrderBy(x => x.Weight).ToList();
        }

        public Edge Pop()
        {
            var edge = edgeList[0];
            edgeList.Remove(edge);
            return edge;
        }

        public int Count()
        {
            return edgeList.Count;
        }

        public List<Edge> GetList()
        {
            return edgeList;
        }
    }
}
