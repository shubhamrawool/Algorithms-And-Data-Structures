namespace Algorithms.Searching_Algorithm
{
    public class LinearSearch
    {
        public int Search(int[] input, int value)
        {
            for(var i = 0; i < input.Length; i++)
            {
                if (input[i] == value)
                    return i;
            }
            return -1;
        }
    }
}
