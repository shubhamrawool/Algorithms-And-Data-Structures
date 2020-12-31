namespace Algorithms.Sorting_Algorithms
{
    public class InsertionSort
    {
        public int[] Sort(int[] input)
        {
            for (var i = 1; i < input.Length; i++)
            {
                var current = input[i];
                var j = i - 1;
                while(j >= 0 && input[j] > current)
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j + 1] = current;
            }
            return input;
        }
    }
}
