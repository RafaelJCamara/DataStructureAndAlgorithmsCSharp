using System;
using DSA.HashTables;

namespace DSA
{
    public class Program
    {
        public static void Main(string[] args) {
            var hashTable = new CustomHashTableWithChaining();
            hashTable.Add(0, "zero");
            hashTable.Add(1, "one");
            hashTable.Add(100, "hundred");
            Console.WriteLine(hashTable.Get(0));
            Console.WriteLine(hashTable.Get(1));
            Console.WriteLine(hashTable.Get(100));
            Console.WriteLine(hashTable.ContainsKey(0));
            Console.WriteLine(hashTable.ContainsKey(100));
            Console.WriteLine(hashTable.ContainsKey(56));
            hashTable.Remove(0);
            Console.WriteLine(hashTable.ContainsKey(0));
            hashTable.Remove(56);
        }
    }
}

