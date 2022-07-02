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
        }
    }
}

