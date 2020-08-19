using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Queue
{
    public class ArrayQueue<T>
    {
        private T[] array;
        private int first = 0;
        private int last = 0;
        private int size = 0;
        public ArrayQueue(int size)
        {
            array = new T[size];
        }

        public bool Enqueue(T item)
        {
            if(IsFull())
            {
                return false;
            }
            array[last] = item;
            last = (last + 1) % array.Length;
            size++;
            return true;
        }

        public T Dequeue()
        {
            var item = array[first];
            array[first] = default(T);
            first = (first + 1) % array.Length;
            size--;
            return item;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public T Peek()
        {
            return array[last];
        }

        public bool IsFull()
        {
            return size == array.Length;
        }

        public override string ToString()
        {
            var str = new StringBuilder("");
            for (var i = 0; i < array.Length; i++)
                str.Append(","  + array[i]);
            return str.ToString();
        }
    }
}
