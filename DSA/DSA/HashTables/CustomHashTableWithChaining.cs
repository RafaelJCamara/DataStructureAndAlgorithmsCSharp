using System;
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

        public void Remove(int key)
        {
            int index = Hash(key);
            var entryList =_dictionary[index];
            //Will throw InvalidOperation exception if key does not exists
            var wasRemoved = entryList.Remove(entryList.First(entry => entry.Key == key));
        }

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

    }
}

