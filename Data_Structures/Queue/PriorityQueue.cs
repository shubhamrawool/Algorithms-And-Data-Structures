using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Queue
{
    public class PriorityQueue
    {
        private int[] array;
        private int count = 0;
        public PriorityQueue(int size)
        {
            array = new int[size];
        }

        public void Enqueue(int value)
        {
            if (IsFull()) increaseArraySize();
            int i = ShiftItemsToInsert(value);
            array[i] = value;
            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty()) throw new IndexOutOfRangeException();
            return array[--count];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        private int ShiftItemsToInsert(int value)
        {
            int i;
            for (i = count - 1; i >= 0; i--)
            {
                if (array[i] > value)
                {
                    array[i + 1] = array[i];
                }
                else
                {
                    break;
                }
            }
            return i + 1;
        }

        private bool IsFull()
        {
            return count == array.Length;
        }

        public override string ToString()
        {
            var output = new StringBuilder("");
            for(int i = 0; i < count; i++)
            {
                output.Append(array[i]);
                output.Append(",");
            }
            return output.ToString();
        }

        private void increaseArraySize()
        {
            var tempArray = new int[count * 2];
            for (var i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            array = tempArray;
        }
    }
}
