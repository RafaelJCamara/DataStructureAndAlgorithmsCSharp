using System;
namespace DSA.HashTables
{
    public class CustomHashTableWithChaining : IHashTable
    {
        /*
            We are using the chaining method to resolve collisions
         */
        private LinkedList<Entry>[] _dictionary;
        private const int ArraySize = 100;

        public CustomHashTableWithChaining()
        {
            this._dictionary = new LinkedList<Entry>[ArraySize];
            for(int i = 0; i != ArraySize; i++)
            {
                _dictionary[i] = new LinkedList<Entry>();
            }
        }

        public void Add(int key, string value)
        {
            int index = Hash(key);
            _dictionary[index].AddLast(new Entry
            {
                Key = key,
                Value = value
            });
        }

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

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {

        }

        private int Hash(int key)
        {
            return key % ArraySize;
        }

    }
}

