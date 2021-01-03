using Algorithms.Sorting_Algorithms;

namespace Algorithms.Searching_Algorithm
{
    public class BinarySearch
    {
        public int Search(int[] input, int value)
        {
            return RecursiveSearch(new MergeSort().Sort((int[])input.Clone()), value, 0, input.Length - 1);
            // return IterativeSearch(new MergeSort().Sort((int[])input.Clone()), value);
        }

        // Iterative Implementation
        private int IterativeSearch(int[] input, int value)
        {
            var leftIndex = 0;
            var rightIndex = input.Length - 1;
            while (rightIndex >= leftIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;
                if (input[middleIndex] == value)
                    return middleIndex;
                else if (input[middleIndex] > value)
                    rightIndex = middleIndex - 1;
                else
                    leftIndex = middleIndex + 1;
            }
            return -1;
        }

        public int RecursiveSearch(int[] input, int value, int leftIndex, int rightIndex)
        {
            if (rightIndex < leftIndex)
                return -1;

            int middleIndex = (leftIndex + rightIndex) / 2;
            if (input[middleIndex] == value)
                return middleIndex;
            else if (input[middleIndex] > value)
                return RecursiveSearch(input, value, leftIndex, middleIndex - 1);
            else
                return RecursiveSearch(input, value, middleIndex + 1, rightIndex);
        }
    }
}
