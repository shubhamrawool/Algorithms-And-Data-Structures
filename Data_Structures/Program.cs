using Data_Structures.Exercise;
using Data_Structures.LinkedLists;
using Data_Structures.Queue;
using Data_Structures.Stack;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            //PerformArrayOps();
            //PerformLinkedListOps();
            //PerformStackOps();
            PerformQueueOps();
            //PerformExcerciseOps();
        }

        private static void PerformArrayOps()
        {
            Arrays<int> value = new Arrays<int>();
            value.Insert(10);
            value.Insert(20);
            value.Insert(30);
            value.RemoveAt(1);
            value.Insert(10);
            Console.WriteLine($"The index of 10 is { value.IndexOf(10) }");
            Console.WriteLine($"The Array is ");
            value.Print();
            Console.ReadLine();
        }

        private static void PerformLinkedListOps()
        {
            var linkedList = new LinkedLists<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(0);
            linkedList.AddLast(-1);
            linkedList.AddLast(4);
            linkedList.Print();
            Console.WriteLine(linkedList.getKthFromTheEnd(2));
            Console.WriteLine("Reverse");
            linkedList.Reverse();
            linkedList.Print();
            linkedList.DeleteFirst();
            linkedList.DeleteLast();
            Console.WriteLine(linkedList.Contains(1));
            Console.WriteLine(linkedList.Contains(21));
            Console.WriteLine(linkedList.IndexOf(1));
            Console.WriteLine(linkedList.IndexOf(21));
            Console.WriteLine(linkedList.ToArray());
            linkedList.Print();
            Console.ReadLine();
        }

        private static void PerformStackOps()
        {
            var stacks = new Stacks<int>(5);
            stacks.Push(1);
            stacks.Push(2);
            Console.WriteLine(stacks.Pop());
            Console.WriteLine(stacks.Peek());
            Console.WriteLine(stacks.IsEmpty());
            Console.ReadLine();
        }

        private static void PerformQueueOps()
        {
            // Queue using array 
            var arrayQueue = new ArrayQueue<int>(5);
            arrayQueue.Enqueue(10);
            arrayQueue.Enqueue(20);
            arrayQueue.Enqueue(30);
            Console.WriteLine(arrayQueue.Dequeue());
            Console.WriteLine(arrayQueue.Dequeue());
            arrayQueue.Enqueue(40);
            arrayQueue.Enqueue(50);
            arrayQueue.Enqueue(60);
            arrayQueue.Enqueue(70);

            // Queue using stack
            Console.WriteLine(arrayQueue.ToString());
            var stackQueue = new StackQueue<int>();
            stackQueue.Enqueue(10);
            stackQueue.Enqueue(20);
            stackQueue.Enqueue(30);
            Console.WriteLine(stackQueue.Dequeue());
            Console.WriteLine(stackQueue.Dequeue());
            Console.ReadLine();

            //Priority Queue
            var priorityQueue = new PriorityQueue(5);
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(8);
            priorityQueue.Enqueue(9);
            priorityQueue.Enqueue(7);
            Console.WriteLine(priorityQueue.ToString());
            Console.ReadLine();
        }

        private static void PerformExcerciseOps()
        {
            var ex = new Excercise();
            Console.WriteLine(ex.ReverseUsingStack("abcdef"));
            Console.WriteLine(ex.IsBalancedExpression2("((([1] + [[3]] ))) <{aaa}>"));
            var queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Console.WriteLine(ex.ReverseQueue<int>(queue));
            Console.ReadLine();
        }
    }
}
