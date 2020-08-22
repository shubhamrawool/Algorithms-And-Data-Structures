using System;
using System.Collections.Generic;

namespace Data_Structures.Queue
{
    public class StackQueue<T>
    {
        // Implementaion 1 : High time complexity due to 2 loops during dequeue
        //private Stack<T> firstStack = new Stack<T>();
        //private Stack<T> backupStack = new Stack<T>();
        //private int size = 0;

        //public void Enqueue(T value)
        //{
        //    firstStack.Push(value);
        //    size++;
        //}

        //public T Dequeue()
        //{
        //    if (size == 0) throw new ArgumentNullException();
        //    int i = size;
        //    while(i != 1)
        //    {
        //        backupStack.Push(firstStack.Pop());
        //        i--;
        //    }
        //    var item = firstStack.Pop();
        //    while(backupStack.Count != 0)
        //    {
        //        firstStack.Push(backupStack.Pop());
        //    }
        //    size--;
        //    return item;
        //}

        //public bool IsEmpty()
        //{
        //    return firstStack.Count == 0;
        //}

        //public T Peek()
        //{
        //    return firstStack.Peek();
        //}


        private Stack<T> enqueueStack = new Stack<T>();
        private Stack<T> dequeueStack = new Stack<T>();

        public void Enqueue(T item)
        {
            enqueueStack.Push(item);
        }

        public T Dequeue()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException();
            }
            MoveItemsToDequeueStack();
            return dequeueStack.Pop();
        }

        public bool IsEmpty()
        {
            return enqueueStack.Count == 0 && dequeueStack.Count == 0;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }
            MoveItemsToDequeueStack();
            return dequeueStack.Peek();
        }

        private void MoveItemsToDequeueStack()
        {
            if (dequeueStack.Count == 0)
            {
                while (enqueueStack.Count != 0)
                    dequeueStack.Push(enqueueStack.Pop());
            }
        }
    }
}
