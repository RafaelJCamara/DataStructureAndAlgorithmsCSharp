﻿using System;
namespace DSA.HashTables
{
    public class CustomHashTableWithChaining : IHashTable
    {
        /*
            We are using the chaining method to resolve collisions
         */
        private LinkedList<Entry>[] _dictionary;
        public LinkedList<Entry>[] Dictionary {
            get
            {
                return _dictionary;
            }
        }
        private const int ArraySize = 100;

        public CustomHashTableWithChaining()
        {
            this._dictionary = new LinkedList<Entry>[ArraySize];
            for(int i = 0; i != ArraySize; i++) _dictionary[i] = new LinkedList<Entry>();
        }

        /*
            Time complexity: O(1)
         */
        public void Add(int key, string value)
        {
            int index = Hash(key);

            var entryList = _dictionary[index];

            foreach(var entry in entryList)
            {
                /*
                    If we insert the same key twice, we want to update the existing value, and not generate a duplicate entry with the same key and different values.
                 */
                if (entry.Key == key) entry.Value = value;
            }

            entryList.AddLast(new Entry
            {
                Key = key,
                Value = value
            });
        }

        /*
            Time complexity: Vast majority of times is O(1).
                             Will depend on the hash algorithm. If our hash algo is bad, we will have many collision, thus this complexity may vary.
         */
        public string Get(int key)
        {
            int index = Hash(key);
            var entryList = _dictionary[index];
            foreach (var entry in entryList)
            {
                if (entry.Key == key) return entry.Value;
            }
            throw new Exception("Key not found!");
        }

        /*
            Time complexity: Vast majority of times is O(1).
                             Will depend on the hash algorithm. If our hash algo is bad, we will have many collision, thus this complexity may vary.
        */
        public bool ContainsKey(int key)
        {
            int index = Hash(key);
            var entryList = _dictionary[index];
            foreach (var entry in entryList)
            {
                if (entry.Key == key)
                {
                    return true;
                }
            }
            return false;
        }

        /*
            Time complexity: Vast majority of times is O(1).
                             Will depend on the hash algorithm. If our hash algo is bad, we will have many collision, thus this complexity may vary.
        */
        public void Remove(int key)
        {
            int index = Hash(key);
            var entryList =_dictionary[index];
            //Will throw InvalidOperation exception if key does not exists
            var wasRemoved = entryList.Remove(entryList.First(entry => entry.Key == key));
        }

        /*
            Time complexity: Vast majority of times is O(1).
                             Will depend on the hash algorithm. If our hash algo is bad, we will have many collision, thus this complexity may vary.
        */
        public Entry GetEntryForKey(int key)
        {
            int index = Hash(key);
            var entryList = _dictionary[index];
            foreach (var entry in entryList)
            {
                if (entry.Key == key) return entry;
            }
            throw new Exception("Key not found!");
        }

        public int Hash(int key)
        {
            return key % ArraySize;
        }


        /*
            There's also another way of solving this, which is using a priority queue.
            When inserting elements in the queue, they will be sorted based on their priority (which is the amount of times the element has occurred)
            When ending this insertion, just Dequeue an element from the queue, and this element will be the element with highest priority, meaning the most amount of times it has occurred
         */
        public static int MostFrequent(int[] array)
        {
            Dictionary<int, int> hashmap = new Dictionary<int, int>();
            foreach(var num in array)
            {
                hashmap[num] = hashmap.GetValueOrDefault(num) + 1;
            }

            var maxElement = -1;
            var mostRepeatedElementTimes = -1;

            foreach(KeyValuePair<int,int> entry in hashmap)
            {
                if (entry.Value > mostRepeatedElementTimes)
                {
                    maxElement = entry.Key;
                    mostRepeatedElementTimes = entry.Value;
                }
            }

            return maxElement;
        }

        /*
            Two sum without using equal numbers
         */
        public int[] TwoSum(int[] array, int target)
        {
            Dictionary<int, int> hashmap = new Dictionary<int, int>();
            for(int i = 0; i != array.Length; i++)
            {
                var complement = target - array[i];
                if (hashmap.ContainsKey(complement) && complement != array[i])
                {
                    return new int[] { hashmap[complement], i};
                }
                hashmap[array[i]] = i;
            }
            return null;
        }

        /*
         * Using HashTables
         */
        public int CountPairsWithDiff(int[] array, int diff)
        {
            Dictionary<int, List<int>> hashmap = new Dictionary<int, List<int>>();
            int numPairs = 0;
            foreach(var num in array)
            {
                int lowerBound = num-diff;
                int higherBound = num+diff;
                if (hashmap.ContainsKey(lowerBound))
                {
                    hashmap[lowerBound].Add(num);
                }
                if (hashmap.ContainsKey(higherBound))
                {
                    hashmap[higherBound].Add(num);
                }
                hashmap[num] = new List<int>();
            }

            foreach (var values in hashmap.Values)
            {
                numPairs += values.Count;
            }

            return numPairs;
        }

        /*
            Using Sets
         */
        public int CountPairsWithDiff2(int[] array, int diff)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (var num in array) set.Add(num);

            var count = 0;

            foreach (var num in array)
            {
                if (set.Contains(num - diff)) count += 1;
                if (set.Contains(num + diff)) count += 1;
                set.Remove(num);
            }

            return count;
        }

    }
}

