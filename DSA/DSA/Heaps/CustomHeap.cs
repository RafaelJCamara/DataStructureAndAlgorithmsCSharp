using System;
namespace DSA.Heaps
{
    public class CustomHeap
    {
        public int[] Heap { get; set; }
        public int Size { get; private set; }

        public CustomHeap(int size)
        {
            Size = size;
            Heap = new int[Size];
        }

        //insert(int)

        //remove()

    }
}

