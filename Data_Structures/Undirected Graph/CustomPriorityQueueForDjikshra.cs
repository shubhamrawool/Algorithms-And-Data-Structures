using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures.Undirected_Graph
{
    public class CustomPriorityQueueForDjikshra
    {

        List<NodeEntry> nodeList = new List<NodeEntry>();
        public int Count { get; set; } = 0;
        public void Push(NodeEntry node)
        {
            var existingNode = nodeList.Find(x => x.Node.Label == node.Node.Label);
            if (existingNode != null)
                existingNode.Priority = node.Priority;
            else
            {
                Count++;
                nodeList.Add(node);
            }

            nodeList = nodeList.OrderBy(x => x.Priority).ToList();
        }

        private void Remove(NodeEntry node)
        {
            Count--;
            nodeList.Remove(node);
        }

        public NodeEntry Pop()
        {
            var returnValue = nodeList[0];
            Remove(returnValue);
            return returnValue;
        }
    }
}
