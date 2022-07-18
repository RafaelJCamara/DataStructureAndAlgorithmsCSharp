using System;
namespace DSA.Heaps
{
    public class CustomHeap
    {
        public int[] Heap { get; set; }
        public int Size { get; private set; }
        public int Current { get; private set; }

        public CustomHeap(int size)
        {
            Size = size;
            Heap = new int[Size];
            Current = -1;
        }

        //insert(int)
        public void Insert(int value)
        {
            if (IsHeapFull()) throw new InvalidOperationException("Heap is full!");
            Heap[++Current] = value;
            BubbleUp();
        }

        private void BubbleUp()
        {
            int aux = Current;
            while (aux>0 && Heap[aux] > Heap[ParentIndex(aux)])
            {
                Swap(aux, ParentIndex(aux));
                aux = ParentIndex(aux);
            }
        }

        private void Swap(int index1, int index2)
        {
            int aux = Heap[index1];
            Heap[index1] = Heap[index2];
            Heap[index2] = aux;
        }

        private bool IsHeapFull()
        {
            return Current == Heap.Length-1;
        }

        private int ParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        //remove()

    }
}

