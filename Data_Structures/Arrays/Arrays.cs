using System;
using System.Collections.Generic;

namespace Data_Structures
{
    public class Arrays<T>
    {
        private T[] array = new T[0];
        private int count = 0;

        public void Insert(T value)
        {
            if (array.Length == count)
            {
                var newArray = new T[count == 0 ? 2 : count * 2];
                for (int i = 0; i < count; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }
            array[count++] = value;
        }

        public void RemoveAt(int index)
        {
            if(index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = index; i < count; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
        }

        public int IndexOf(T value)
        {
            for(var i=0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Print()
        {
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
