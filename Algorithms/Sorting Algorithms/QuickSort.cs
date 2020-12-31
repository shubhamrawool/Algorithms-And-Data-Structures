using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting_Algorithms
{
    public class QuickSort
    {
        public int[] Sort(int[] input)
        {
            Sort(input, 0, input.Length - 1);
            return input;
        }

        // Better implementation
        private void Sort(int[] input, int start, int end)
        {
            if (start >= end)
                return;
            var boundary = Partition(input, start, end);
            Sort(input, start, boundary - 1);
            Sort(input, boundary + 1, end);
        }

        private int Partition(int[] input, int start, int end)
        {
            var pivot = input[end];
            var boundary = start - 1;
            for(var i = start; i<= end; i++)
            {
                if (input[i] <= pivot)
                    Swap(input, i, ++boundary);
            }
            return boundary;
        }


        // Initial Implementation;
        //private void Sort(int[] input, int boundary, int pivotIndex)
        //{
        //    int temp = boundary;
        //    if (boundary == pivotIndex)
        //    {
        //        return;
        //    }
        //    for (var i = boundary + 1; i < pivotIndex; i++)
        //    {
        //        if (input[i] < input[pivotIndex])
        //        {
        //            Swap(input, i, ++boundary);
        //        }
        //    }
        //    Swap(input, ++boundary, pivotIndex);
        //    Sort(input, -1, boundary - 1);
        //    if (temp != boundary)
        //        Sort(input, boundary, pivotIndex);
        //}

        private void Swap(int[] input, int index1, int index2)
        {
            var temp = input[index1];
            input[index1] = input[index2];
            input[index2] = temp;
        }
    }
}
