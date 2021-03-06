﻿using Algorithms.Searching_Algorithm;
using Algorithms.Sorting_Algorithms;
using Algorithms.String_Manipulation_Algorithms;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExecuteSortingAlorithms();
            //ExecuteSearchingAlgorithms();
            ExecuteStringManipulationAlgorithms();
        }

        private static void ExecuteSortingAlorithms()
        {
            var arrayToSort = new int[7] { 7, 3, 1, 4, 6, 2, 5 };
            Console.WriteLine("Comparison-Based Sorting Algorithms");
            Console.WriteLine("Array To Sort : " + arrayToSort.Print());
            Console.WriteLine("Executing Bubble Sort :" + new BubbleSort().Sort((int[])arrayToSort.Clone()).Print());
            Console.WriteLine("Executing Selection Sort : " + new SelectionSort().Sort((int[])arrayToSort.Clone()).Print());
            Console.WriteLine("Executing Insertion Sort : " + new InsertionSort().Sort((int[])arrayToSort.Clone()).Print());
            Console.WriteLine("Executing Merge Sort : " + new MergeSort().Sort((int[])arrayToSort.Clone()).Print());
            Console.WriteLine("Executing Quick Sort : " + new QuickSort().Sort((int[])arrayToSort.Clone()).Print());

            Console.WriteLine("\nNon-Comparison-Based Sorting Algorithms");
            Console.WriteLine("Executing Counting Sort : " + new CountingSort().Sort((int[])arrayToSort.Clone(), 8).Print());
            Console.WriteLine("Executing Bucket Sort : " + new BucketSort().Sort((int[])arrayToSort.Clone(),3).Print());
        }

        private static void ExecuteSearchingAlgorithms()
        {
            var arrayToSearch = new int[7] { 7, 3, 1, 4, 6, 2, 5 };
            var valueToSearch = 6;
            Console.WriteLine("Searching for a value 6");
            Console.WriteLine("Executing Linear Search : Index of 6 - " + new LinearSearch().Search(arrayToSearch, valueToSearch));
            Console.WriteLine("Executing Binary Search : Index of 6 - " + new BinarySearch().Search(arrayToSearch, valueToSearch));
            Console.WriteLine("Executing Ternary Search : Index of 6 - " + new TernarySearch().Search(arrayToSearch, valueToSearch));
            Console.WriteLine("Executing Jump Search : Index of 6 - " + new JumpSearch().Search(arrayToSearch, valueToSearch));
            Console.WriteLine("Executing Exponential Search : Index of 6 -" + new ExponentialSearch().Search(arrayToSearch, valueToSearch));
        }

        private static void ExecuteStringManipulationAlgorithms()
        {
            var stringToManipulate = "hellooo  worldddd!!!";
            var stringUtils = new StringUtils();
            Console.WriteLine("Reversing a string" + stringUtils.ReverseString(stringToManipulate));
            Console.WriteLine("Number of vowels in string : " + stringUtils.CountVowels(stringToManipulate));
            Console.WriteLine("Reversing a word : " + stringUtils.ReverseWords(stringToManipulate));
            Console.WriteLine("Check If String is Rotation of Another : 'ABCD' -- 'CDAB' : " + stringUtils.CheckRotation("ABCD", "CDBA"));
            Console.WriteLine("Removing Duplicates from string : " + stringUtils.RemoveDuplicates(stringToManipulate));
            Console.WriteLine("Most Repeated character in string : " + stringUtils.MostRepeatedCharacter(stringToManipulate));
            Console.WriteLine("Capitalizing Word in sentence : " + stringUtils.CapitalizeSentence(stringToManipulate));
            Console.WriteLine("Check If Anagram : " + stringUtils.CheckAnagramHistogramming("ABCD", "DCAE"));
            Console.WriteLine("Check If Palindrom : " + stringUtils.CheckPalindrom("ABBA"));
        }
    }
}
