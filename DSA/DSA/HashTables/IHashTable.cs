using System;
namespace DSA.HashTables
{
    public interface IHashTable
    {
        void Add(int key, string value);
        string Get(int key);
        bool ContainsKey(int key);
        void Remove(int key);
    }
}

