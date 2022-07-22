using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Heaps
{
    public class MaxHeap
    {
        public static void Heapify(int[] array)
        {
            while (!HeapInValidState(array, 0))
            {
                for(int i = 0; i < array.Length; i++)
                {
                    Heapify(array, i);
                }
            }
        }

        private static bool HeapInValidState(int[] array, int root)
        {
            //root is bigger than left and right child and same happens in the subtrees
            int leftChildIndex = root * 2 + 1;
            int rightChildIndex = root * 2 + 2;

            if (leftChildIndex > array.Length && rightChildIndex > array.Length) return true;

            if (leftChildIndex < array.Length && array[leftChildIndex] > array[root] 
                || rightChildIndex < array.Length && array[rightChildIndex] > array[root]) return false;

            return true && HeapInValidState(array, leftChildIndex) && HeapInValidState(array, rightChildIndex);
        }

        private static void Heapify(int[] array, int index)
        {
            var largerIndex = index;

            var leftIndex = index * 2 + 1;
            if (leftIndex < array.Length &&
                array[leftIndex] > array[largerIndex])
                largerIndex = leftIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < array.Length &&
              array[rightIndex] > array[largerIndex])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);
            Heapify(array, largerIndex);
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            int aux = array[index1];
            array[index1] = array[index2];
            array[index2] = aux;
        }

    }
}
