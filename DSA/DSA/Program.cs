using System;
using DSA.HashTables;
using DSA.Queues.PriorityQueues;
using DSA.Trees.BinarySearchTree;

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
            /*
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
            */

            var bst = new BST();
            bst.Insert(10);
            bst.Insert(6);
            bst.Insert(3);
            bst.Insert(8);
            bst.Insert(1);
            bst.Insert(2);
            bst.Insert(7);
            bst.Insert(9);
            bst.Insert(17);
            bst.Insert(14);
            bst.Insert(13);
            bst.Insert(15);
            bst.Insert(20);
            bst.Insert(18);
            bst.Insert(21);
            Console.WriteLine(bst.Height());
        }
    }
}

