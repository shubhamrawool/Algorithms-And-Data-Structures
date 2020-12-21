using Data_Structures.AVLTrees;
using Data_Structures.BinaryTree;
using Data_Structures.Exercise;
using Data_Structures.HashTable;
using Data_Structures.LinkedLists;
using Data_Structures.Queue;
using Data_Structures.Stack;
using Data_Structures.Heaps;
using System;
using System.Collections.Generic;
using Data_Structures.Trie;
using Data_Structures.Graph;
using Data_Structures.Undirected_Graph;

namespace Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            //PerformArrayOps();
            //PerformLinkedListOps();
            //PerformStackOps();
            //PerformQueueOps();
            //PerformHashTableOps();
            //PerfomBinaryTreeOps();
            //PerformAVLTreeOps();
            //PerformHeapOps();
            //PerformTrieOps();
            //PerformGraphOps();
            PerformUndirectedGraphOps();
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

        private static void PerformHashTableOps()
        {
            var hashTable = new HashTables(5);
            hashTable.Put(1, "a");
            hashTable.Put(6, "aa");
            hashTable.Put(11, "aaa");
            Console.WriteLine(hashTable.Get(11));
            hashTable.Remove(6);
            hashTable.Put(1, "a");
            hashTable.Put(2, "b");
            Console.WriteLine("abc");
        }

        private static void PerfomBinaryTreeOps()
        {
            var binaryTree = new BinaryTrees();
            binaryTree.Insert(7);
            binaryTree.Insert(4);
            binaryTree.Insert(9);
            binaryTree.Insert(1);
            binaryTree.Insert(6);
            binaryTree.Insert(8);
            binaryTree.Insert(10);
            Console.WriteLine(binaryTree.Find(8));
            Console.WriteLine(binaryTree.Find(13));
            Console.WriteLine("Pre Order Traversal");
            binaryTree.TraverseTreePreOrder();
            Console.WriteLine("In Order Traversal");
            binaryTree.TraverseTreeInOrder();
            Console.WriteLine("Post Order Traversal");
            binaryTree.TraverseTreePostOrder();
            Console.WriteLine("Height of tree is " + binaryTree.TreeHeight());

            var binaryTree2 = new BinaryTrees();
            binaryTree2.Insert(7);
            binaryTree2.Insert(4);
            binaryTree2.Insert(3);
            binaryTree2.Insert(9);
            binaryTree2.Insert(1);
            binaryTree2.Insert(6);
            binaryTree2.Insert(8);
            binaryTree2.Insert(10);

            Console.WriteLine("Two binary trees are equal :" + binaryTree.IsEqual(binaryTree2));
            Console.WriteLine("Binary Tree is binary search tree : " + binaryTree.IsBinarySearchTree());

            Console.WriteLine(string.Join(",", binaryTree.GetNodesAtKDistance(2).ToArray()));

            Console.WriteLine("Level Order Traversal");
            binaryTree.LevelOrderTraversal();

            Console.ReadLine();
        }

        public static void PerformAVLTreeOps()
        {
            var avlTree = new AVLTree();
            avlTree.Insert(7);
            avlTree.Insert(5);
            avlTree.Insert(12);
            avlTree.Insert(6);
            avlTree.Insert(9);
            avlTree.Insert(11);
            avlTree.Insert(13);
            Console.ReadLine();
        }

        public static void PerformHeapOps()
        {
            var heap = new Heaps.Heaps(10);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(3);
            heap.Insert(8);
            heap.Insert(12);
            heap.Insert(9);
            heap.Insert(4);
            heap.Insert(1);
            heap.Insert(24);
            heap.Remove();
            var array = new int[5] { 10, 20, 30, 40, 50 };
            var heapArray = MaxHeap.Heapify(array);
            Console.WriteLine(MaxHeap.KthLargestItem(array, 2));
        }

        private static void PerformTrieOps()
        {
            var tri = new TriesUsingHashmap();
            tri.Insert("car");
            tri.Insert("care");
            tri.Insert("card");
            tri.Insert("cardio");
            var list = tri.AutoComplete("car");

            tri.Insert("cat");
            tri.Insert("catch");
            Console.WriteLine(tri.Contains("cat"));
            Console.WriteLine(tri.Contains("catc"));
            tri.Traverse();
            tri.Remove("catch");
        }

        private static void PerformGraphOps()
        {
            var graph = new Graphs();
            graph.AddNode("a");
            graph.AddNode("b");
            graph.AddNode("c");
            graph.AddEdge("a", "b");
            graph.AddEdge("a", "c");
            graph.Print();

            var graph2 = new Graphs();
            graph2.AddNode("a");
            graph2.AddNode("b");
            graph2.AddNode("c");
            graph2.AddNode("d");
            graph2.AddEdge("a", "b");
            graph2.AddEdge("a", "c");
            graph2.AddEdge("b", "d");
            graph2.AddEdge("d", "c");
            Console.WriteLine("Recursive Depth First Traversal");
            graph2.RecursiveDepthFirstTraversal("a");
            Console.WriteLine("Iterative Depth First Traversal");
            graph2.IterativeDepthFirstTraversal("a");
            Console.WriteLine("Breadth First Traversal");
            graph2.BreadthFirstTraversal("a");

            var graph3 = new Graphs();
            graph3.AddNode("x");
            graph3.AddNode("a");
            graph3.AddNode("b");
            graph3.AddNode("p");
            graph3.AddEdge("x", "a");
            graph3.AddEdge("x", "b");
            graph3.AddEdge("a", "p");
            graph3.AddEdge("b", "p");

            Console.WriteLine("Topolocally Sorted List");
            graph3.TopologicalSort().ForEach(x =>
            {
                Console.WriteLine(x);
            });

            var graph4 = new Graphs();
            graph4.AddNode("a");
            graph4.AddNode("b");
            graph4.AddNode("c");
            graph4.AddNode("d");
            graph4.AddEdge("a", "b");
            graph4.AddEdge("b", "c");
            graph4.AddEdge("c", "a");
            graph4.AddEdge("a", "d");
            Console.WriteLine("Graph contains Cycle" + graph4.IsCyclePresent());
        }

        public static void PerformUndirectedGraphOps()
        {
            var undirectedGraph = new UndirectedGraph();
            undirectedGraph.AddNode("A");
            undirectedGraph.AddNode("B");
            undirectedGraph.AddNode("C");
            undirectedGraph.AddEdge("A", "B", 3);
            undirectedGraph.AddEdge("A", "C", 2);
            undirectedGraph.Print();

            Console.WriteLine("Dijkstra Start");

            var dijkstraDemo = new UndirectedGraph();
            dijkstraDemo.AddNode("A");
            dijkstraDemo.AddNode("B");
            dijkstraDemo.AddNode("C");
            dijkstraDemo.AddNode("D");
            dijkstraDemo.AddNode("E");
            dijkstraDemo.AddEdge("A", "B", 3);
            dijkstraDemo.AddEdge("A", "C", 4);
            dijkstraDemo.AddEdge("A", "D", 2);
            dijkstraDemo.AddEdge("B", "D", 6);
            dijkstraDemo.AddEdge("B", "E", 1);
            dijkstraDemo.AddEdge("C", "D", 1);
            dijkstraDemo.AddEdge("D", "E", 5);
            dijkstraDemo.Print();
            Console.WriteLine("Shortest Path from A to E is : " + dijkstraDemo.GetShortestDistance("A", "E"));

            Console.WriteLine("Cycle Detection");
            var cycleDetectionDemo = new UndirectedGraph();
            cycleDetectionDemo.AddNode("A");
            cycleDetectionDemo.AddNode("B");
            cycleDetectionDemo.AddNode("C");
            cycleDetectionDemo.AddNode("D");
            cycleDetectionDemo.AddEdge("A", "B", 1);
            cycleDetectionDemo.AddEdge("B", "C", 1);
            cycleDetectionDemo.AddEdge("C", "A", 2);
            cycleDetectionDemo.Print();
            Console.WriteLine("The graph contains cycle : " + cycleDetectionDemo.HasCycles());

            Console.WriteLine("Prim's Algorithm for Minimum Spanning Tree");
            var primDemo = new UndirectedGraph();
            primDemo.AddNode("A");
            primDemo.AddNode("B");
            primDemo.AddNode("C");
            primDemo.AddNode("D");
            primDemo.AddEdge("A", "B", 3);
            primDemo.AddEdge("A", "C", 1);
            primDemo.AddEdge("B", "C", 2);
            primDemo.AddEdge("B", "D", 4);
            primDemo.AddEdge("C", "D", 5);
            primDemo.Print();
            Console.WriteLine("Minimum Spanning Tree is : ");
            primDemo.FindMinimumSpanningTree().Print();
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
            Console.WriteLine(ex.FindNonRepeatingCharacter("aahhccaaffqqi"));
            Console.WriteLine(ex.FindRepeatingCharacter("apple"));
            Console.ReadLine();
        }
    }
}
