using System;
using System.Collections.Generic;

namespace Data_Structures.LinkedLists
{
    public class LinkedLists<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.value = value;
            }
            public T value;
            public Node next;
        }

        private Node first { get; set; }
        private Node last { get; set; }
        public int Length { get; private set; }

        public void AddFirst(T value)
        {
            var node = new Node(value);
            if (IsEmpty())
            {
                first = last = node;
            }
            else
            {
                node.next = first;
                first = node;
            }
            Length++;
        }

        public void AddLast(T value)
        {
            var node = new Node(value);
            if (IsEmpty())
            {
                first = last = node;
            }
            else
            {
                last.next = node;
                last = node;
            }
            Length++;
        }

        public void DeleteFirst()
        {
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException();
            }
            if (first == last)
            {
                first = last = null;
                return;
            }
            var node = first.next;
            first.next = null;
            first = node;
            Length--;
        }

        public void DeleteLast()
        {
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException();
            }
            if (first == last)
            {
                first = last = null;
            }
            else
            {
                var node = GetPreviousNode(last);
                last = node;
                last.next = null;
            }
            Length--;
        }

        public int IndexOf(T value)
        {
            var node = first;
            var index = 0;
            while (node != null)
            {
                if (EqualityComparer<T>.Default.Equals(node.value, value))
                {
                    return index;
                }
                node = node.next;
                index++;
            }
            return -1;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public T[] ToArray()
        {
            var array = new T[Length];
            var current = first;
            var index = 0;
            while(current != null)
            {
                array[index++] = current.value;
                current = current.next;
            }
            return array;
        }

        public void Print()
        {
            var node = first;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
        }

        public void Reverse()
        {
            if (IsEmpty())
            {
                return;
            }
            var previous = first;
            var current = previous.next;
            while(current != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            last = first;
            last.next = null;
            first = previous;
        }

        public T getKthFromTheEnd(int k)
        {
            if(k < 0 || IsEmpty())
            {
                throw new InvalidOperationException();
            }
            var trackingNode = first;
            var targetNode = first;
            for(var i = 0; i < k-1; i++)
            {
                trackingNode = trackingNode.next;
                if(trackingNode == null)
                {
                    throw new InvalidOperationException();
                }
            }
            while(trackingNode != last)
            {
                targetNode = targetNode.next;
                trackingNode = trackingNode.next;
            }
            return targetNode.value;   
        }

        private bool IsEmpty()
        {
            return first == null;
        }

        private Node GetPreviousNode(Node node)
        {
            var current = first;
            while (current != null)
            {
                if (current.next == node) return current;
                current = current.next;
            }
            return null;
        }
    }
}
