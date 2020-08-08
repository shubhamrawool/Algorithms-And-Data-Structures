using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Stack
{
    public class Stacks<T>
    {
        public Stacks(int length)
        {
            stackArray = new T[length];
        }
        private T[] stackArray;
        private int Length = 0;

        public void Push(T value)
        {
            if(Length == stackArray.Length)
            {
                throw new StackOverflowException();
            }
            stackArray[Length++] = value;
        }

        public T Pop()
        {
            if (Length == 0) throw new InvalidOperationException();
            return stackArray[--Length];
        }

        public T Peek()
        {
            if (Length == 0) throw new InvalidOperationException();
            return stackArray[Length - 1];
        }

        public bool IsEmpty()
        {
            return Length == 0;
        }
    }
}
