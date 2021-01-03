using Algorithms.Sorting_Algorithms;

namespace Algorithms.Searching_Algorithm
{
    public class TernarySearch
    {
        public int Search(int[] input, int value)
        {
            return RecursiveSearch(new MergeSort().Sort((int[])input.Clone()), value, 0, input.Length - 1);
        }

        private int RecursiveSearch(int[] input, int value, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
                return -1;

            var partitionNumber = (rightIndex - leftIndex) / 3;
            var midIndex1 = leftIndex + partitionNumber;
            var midIndex2 = rightIndex - partitionNumber;

            if (input[midIndex1] == value)
                return midIndex1;

            if (input[midIndex2] == value)
                return midIndex2;

            if (input[midIndex1] > value)
                return RecursiveSearch(input, value, leftIndex, midIndex1 - 1);

            if (input[midIndex2] < value)
                return RecursiveSearch(input, value, midIndex2 + 1, rightIndex);

            return RecursiveSearch(input, value, midIndex1 + 1, midIndex2 - 1);
        }
    }
}
