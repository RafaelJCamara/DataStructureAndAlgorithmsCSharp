using System;
using DSA.HashTables;
using DSA.Queues.PriorityQueues;

namespace DSA
{
    public class Program
    {
        public static void Main(string[] args) {
            /*
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
            */
            var priorityQueue = new PriorityQueue<string, int>(new ElementComparer());
            priorityQueue.Enqueue("A", 4);
            priorityQueue.Enqueue("B", 1);
            priorityQueue.Enqueue("C", 2);
            priorityQueue.Enqueue("D", 5);
            priorityQueue.Enqueue("E", 3);
            while (priorityQueue.TryDequeue(out string item, out int priority))
            {
                Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
            }
        }
    }
}

