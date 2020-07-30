using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.LinkedLists
{
    public class LinkedLists<T>
    {
        private class Node<T>
        {
            public Node(T value)
            {
                this.value = value;
            }
            public T value;
            public Node<T> next;
        }

        private Node<T> first { get; set; }
        private Node<T> last { get; set; }
        public int Length { get; private set; }

        public void AddFirst(T value)
        {
            var node = new Node<T>(value);
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
            var node = new Node<T>(value);
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

        private bool IsEmpty()
        {
            return first == null;
        }

        private Node<T> GetPreviousNode(Node<T> node)
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
