using System.Collections.Generic;

namespace Algorithms.Sorting_Algorithms
{
    public class BucketSort
    {
        public int[] Sort(int[] input, int numberOfBuckets = 3)
        {
            var inputPointer = 0;
            foreach (var bucket in CreateBuckets(input, numberOfBuckets))
            {
                bucket.Sort();
                foreach (var number in bucket)
                    input[inputPointer++] = number;
            }
            return input;
        }

        private List<int>[] CreateBuckets(int[] input, int numberOfBuckets)
        {
            List<int>[] buckets = new List<int>[numberOfBuckets];
            for (var i = 0; i < buckets.Length; i++)
                buckets[i] = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                var bucketIndex = input[i] / numberOfBuckets;
                buckets[bucketIndex].Add(input[i]);
            }

            return buckets;
        }
    }
}
