using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures.Heaps
{
    public class Heaps
    {
        int[] heapArray;
        int count = 0;
        public Heaps(int size)
        {
            heapArray = new int[size];
        }

        public void Insert(int value)
        {
            if (count != heapArray.Length - 1)
                heapArray[count++] = value;
            BubbleUp();
        }

        public int Remove()
        {
            if (count == 0)
                throw new ArgumentNullException();
            var root = heapArray[0];
            heapArray[0] = heapArray[(count--) - 1];
            BubbleDown();
            return root;
        }

        private void BubbleUp()
        {
            var index = count - 1;
            while (index > 0 && heapArray[ParentIndex(index)] < heapArray[index])
            {
                SwapValuesByIndex(ParentIndex(index), index);
                index = ParentIndex(index);
            }
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= count && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                SwapValuesByIndex(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        public int KthLargestItem(int k)
        {
            return FindLargestItem(0, k);
        }

        private int FindLargestItem(int index, int k)
        {
            if (k == 1)
                return heapArray[index];
            return GetLeftChild(index) > GetRightChild(index) ? FindLargestItem(LeftChildIndex(index), --k) : FindLargestItem(RightChildIndex(index), --k);
        }

        public int Max()
        {
            if (count == 0)
                throw new ArgumentNullException();
            return heapArray[0];
        }

        private void SwapValuesByIndex(int sourceIndex, int targetIndex)
        {
            var temp = heapArray[sourceIndex];
            heapArray[sourceIndex] = heapArray[targetIndex];
            heapArray[targetIndex] = temp;
        }

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int LeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        private int RightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

        private int GetLeftChild(int index)
        {
            return heapArray[LeftChildIndex(index)];
        }

        private int GetRightChild(int index)
        {
            return heapArray[RightChildIndex(index)];
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= count - 1;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= count - 1;
        }

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return RightChildIndex(index);
            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return GetLeftChild(index) > GetRightChild(index) ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = heapArray[index] >= heapArray[LeftChildIndex(index)];

            if (HasRightChild(index))
                isValid &= isValid && heapArray[index] >= heapArray[RightChildIndex(index)];

            return isValid;
        }
    }
}
