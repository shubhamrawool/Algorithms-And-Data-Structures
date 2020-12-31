namespace Algorithms.Sorting_Algorithms
{
    public class BubbleSort
    {
        public int[] Sort(int[] input)
        {
            bool isSorted;
            for (var i = 0; i < input.Length; i++)
            {
                isSorted = true;
                for (var j = 1; j < input.Length - i; j++)
                {
                    if(input[j] < input[j - 1])
                    {
                        Swap(input, j, j - 1);
                        isSorted = false;
                    }
                }
                if (isSorted) return input;
            }
            return input;
        }

        private void Swap(int[] input, int index1, int index2)
        {
            var temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }
    }
}
