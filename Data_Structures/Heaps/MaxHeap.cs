using System;

namespace Data_Structures.Heaps
{
    public class MaxHeap
    {
        public static int[] Heapify(int[] array)
        {
            var startIndex = ( array.Length / 2 ) - 1;
            for(var i = startIndex; i >= 0 ; i--)
            {
                Heapify(array, i, array.Length);
            }
            return array;
        }

        public static void Heapify(int[] array, int index, int arrayLength)
        {
            var largerIndex = index;
            var leftIndex = index * 2 + 1;
            if(leftIndex < arrayLength && array[leftIndex] > array[index])
            {
                largerIndex = leftIndex;
            }

            var rightIndex = index * 2 + 2;
            if (rightIndex < arrayLength && array[rightIndex] > array[index])
            {
                largerIndex = rightIndex;
            }

            if (index == largerIndex)
                return;

            SwapByIndex(array, index, largerIndex);
            Heapify(array, largerIndex, arrayLength);
        }

        public static void SwapByIndex(int[] array, int source, int target)
        {
            var temp = array[source];
            array[source] = array[target];
            array[target] = temp;
        }

        public static int KthLargestItem(int[] array, int k)
        {
            if (k < 1 || k > array.Length)
                throw new ArgumentOutOfRangeException();
            var heap = new Heaps(7);
            for(var i = 0; i < array.Length; i++)
            {
                heap.Insert(array[i]);
            }
            for (var i = 0; i < k - 1; i++)
                heap.Remove();
            return heap.Max();
        }
    }
}
