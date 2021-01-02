using Algorithms.Sorting_Algorithms;
using System;

namespace Algorithms.Searching_Algorithm
{
    class JumpSearch
    {
        public int Search(int[] input, int value)
        {
            return IterativeSearch(new MergeSort().Sort((int[])input.Clone()), value);
        }

        private int IterativeSearch(int[] input, int value)
        {
            var blockSize = (int)Math.Sqrt(input.Length);
            var startPointer = 0;
            var nextPointer =  blockSize;
            while (input[nextPointer - 1] < value && startPointer < input.Length)
            {
                startPointer = nextPointer;
                nextPointer = nextPointer + blockSize;
                if (nextPointer > input.Length)
                    nextPointer = input.Length;
            }

            for (var i = startPointer; i < nextPointer; i++)
            {
                if (input[i] == value)
                    return i;
            }
            return -1;
        }
    }
}
