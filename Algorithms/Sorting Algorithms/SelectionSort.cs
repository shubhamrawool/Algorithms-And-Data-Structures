namespace Algorithms.Sorting_Algorithms
{
    public class SelectionSort
    {
        public int[] Sort(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var minimumIndex = FindMinimumIndex(input, i);
                Swap(input, i, minimumIndex);
            }
            return input;
        }

        private int FindMinimumIndex(int[] input, int minimumIndex)
        {
            for (var j = minimumIndex + 1; j < input.Length; j++)
            {
                if (input[j] < input[minimumIndex])
                    minimumIndex = j;
            }
            return minimumIndex;
        }

        private void Swap(int[] input, int index1, int index2)
        {
            var temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }
    }
}
