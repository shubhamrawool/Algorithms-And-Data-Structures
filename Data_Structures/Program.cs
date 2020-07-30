﻿using Data_Structures.LinkedLists;
using System;

namespace Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            //PerformArrayOps();
            PerformLinkedListOps();
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
    }
}