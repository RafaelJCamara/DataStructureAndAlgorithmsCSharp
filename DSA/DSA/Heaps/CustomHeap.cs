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
        public void Remove()
        {
            if (Current == -1) throw new InvalidOperationException("Heap is empty!");
            Heap[0] = Heap[Size - 1];
            Size -= 1;
            BubbleDown();
        }

        public void BubbleDown()
        {
            var currentIndex = 0;
            while(currentIndex<=Size && !IsValidParent(currentIndex))
            {
                var largestChildIndex = LargestChildIndex(currentIndex);
                Swap(largestChildIndex, currentIndex);
                currentIndex = largestChildIndex;
            }
        }

        private bool IsValidParent(int parent)
        {
            if (!HasLeftChild(parent)) return true;
            if (!HasRightChild(parent)) return Heap[parent] >= Heap[LeftChild(parent)];
            return Heap[parent] >= Heap[LeftChild(parent)] && Heap[parent] >= Heap[RightChild(parent)];
        }

        private int LeftChild(int parent)
        {
            return parent * 2 + 1;
        }

        private int RightChild(int parent)
        {
            return parent * 2 + 2;
        }

        private int LargestChildIndex(int parent)
        {
            if (!HasLeftChild(parent)) return parent;
            if (!HasRightChild(parent)) return LeftChild(parent);
            return Heap[LeftChild(parent)] > Heap[RightChild(parent)] ?
                LeftChild(parent) : RightChild(parent);
        }

        private bool HasLeftChild(int parent)
        {
            return LeftChild(parent) < Size;
        }

        private bool HasRightChild(int parent)
        {
            return RightChild(parent) < Size;
        }

        public bool IsMaxHeap(int[] array)
        {
            return IsMaxHeap(array, 0);
        }

        private bool IsMaxHeap(int[] array, int parent)
        {
            int leftChild = LeftChild(parent);
            int rightChild = RightChild(parent);

            if (leftChild > array.Length && rightChild > array.Length) return true;

            if ( (leftChild < array.Length && array[parent] < array[leftChild]) ||
                 (rightChild<array.Length && array[parent] < array[rightChild]) ) return false;

            return IsMaxHeap(array, leftChild) && IsMaxHeap(array, rightChild);
        }

    }
}

