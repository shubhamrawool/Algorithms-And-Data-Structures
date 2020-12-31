namespace Algorithms.Sorting_Algorithms
{
    public class CountingSort
    {
        public int[] Sort(int[] input, int max)
        {
            var countArray = new int[max + 1];
            foreach(var item in input)
            {
                countArray[item]++;
            }
            int inputPointer = 0;
            for(var i = 0; i < countArray.Length; i++)
            {
                var count = countArray[i];
                while(count > 0)
                {
                    input[inputPointer++] = i;
                    count--;
                }
            }
            return input;
        }
    }
}
