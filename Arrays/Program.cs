using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
