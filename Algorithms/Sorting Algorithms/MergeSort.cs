namespace Algorithms.Sorting_Algorithms
{
    public class MergeSort
    {
        public int[] Sort(int[] input)
        {
            SortArray(input);
            return input;
        }

        // Recursive Implementation better approach
        private void SortArray(int[] input)
        {
            if (input.Length == 1)
            {
                return;
            }
            var middleIndex = input.Length / 2;
            var firstArray = new int[middleIndex];
            var secondArray = new int[input.Length - middleIndex];
            for (var i = 0; i < input.Length; i++)
            {
                if (i < middleIndex) firstArray[i] = input[i];
                else secondArray[i - middleIndex] = input[i];
            }
            SortArray(firstArray);
            SortArray(secondArray);

            Merge(firstArray, secondArray, input);
        }

        private void Merge(int[] left, int[] right, int[] result)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                result[k++] = left[i++];
            }
            while (j < right.Length)
            {
                result[k++] = right[j++];
            }
        }


        // Recursive Implementation first approach
        //private void SortArray(int[] input)
        //{
        //    if (input.Length == 1)
        //    {
        //        return;
        //    }
        //    var middleIndex = input.Length / 2;
        //    var firstArray = new int[middleIndex];
        //    var secondArray = new int[input.Length - middleIndex];
        //    for (var i = 0; i < input.Length; i++)
        //    {
        //        if (i < middleIndex) firstArray[i] = input[i];
        //        else secondArray[i - middleIndex] = input[i];
        //        i++;
        //    }

        //    SortArray(firstArray);
        //    SortArray(secondArray);
        //    int firstArrayPointer = 0, secondArrayPointer = 0;
        //    while ((firstArrayPointer + secondArrayPointer) != input.Length)
        //    {
        //        if (firstArrayPointer != firstArray.Length)
        //        {
        //            if (secondArrayPointer == secondArray.Length || firstArray[firstArrayPointer] < secondArray[secondArrayPointer])
        //                input[firstArrayPointer + secondArrayPointer] = firstArray[firstArrayPointer++];
        //            else
        //                input[firstArrayPointer + secondArrayPointer] = secondArray[secondArrayPointer++];
        //        }
        //        else
        //        {
        //            input[firstArrayPointer + secondArrayPointer] = secondArray[secondArrayPointer++];
        //        }
        //    }
        //}
    }
}