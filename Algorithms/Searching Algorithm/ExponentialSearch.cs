using Algorithms.Sorting_Algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Searching_Algorithm
{
    public class ExponentialSearch
    {
        public int Search(int[] input, int value)
        {
            new MergeSort().Sort(input);
            var bound = 1;
            while (bound < input.Length && input[bound] < value)
            {
                bound = bound * 2;
            }
            var leftIndex = bound / 2;
            var rightIndex = Math.Min(bound, input.Length - 1);
            return new BinarySearch().RecursiveSearch(input, value, leftIndex, rightIndex);
        }
    }
}
