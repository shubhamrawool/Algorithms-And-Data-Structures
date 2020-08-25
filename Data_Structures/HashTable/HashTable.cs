using System;
using System.Collections.Generic;

namespace Data_Structures.HashTable
{
    public class HashTables
    {
        private LinkedList<Entry>[] hashArray;

        public HashTables(int size)
        {
            hashArray = new LinkedList<Entry>[size];
        }

        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.Value = value;
                return;
            }

            GetOrCreateBucket(key).AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);
            return entry != null ? entry.Value : null;
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry == null)
                throw new KeyNotFoundException();
            GetBucket(key).Remove(entry);
        }

        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = hashFunction(key);
            var bucket = hashArray[index];
            if (bucket == null)
                hashArray[index] = new LinkedList<Entry>();
            return bucket;
        }

        private LinkedList<Entry> GetBucket(int key)
        {
            return hashArray[hashFunction(key)];
        }

        private Entry GetEntry(int key)
        {
            var bucket = GetBucket(key);
            if (bucket != null)
            {
                foreach (var node in bucket)
                {
                    if (node.Key == key)
                        return node;
                }
            }
            return null;
        }

        private int hashFunction(int key)
        {
            return Math.Abs(key) % hashArray.Length;
        }

        private class Entry
        {
            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}
