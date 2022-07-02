using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Stack
{
    public class CustomStack
    {
        private int[] _stack;
        private int current = -1;
        public const int StackSize = 100;
        public int[] ItemStack
        {
            get { return _stack; }
        }

        public CustomStack()
        {
            _stack = new int[StackSize];
        }

        /*
            Time complexity: O(1)
         */
        public void Push(int item)
        {
            if (current == StackSize - 1) throw new Exception("Stack is full!");
            _stack[++current] = item;
        }

        /*
            Time complexity: O(1)
        */
        public int Pop()
        {
            if (current == -1) throw new Exception("Stack is empty!");
            return _stack[current--];
        }

        /*
            Time complexity: O(1)
        */
        public int Peek()
        {
            if (current == -1) throw new Exception("Stack is empty!");
            return _stack[current];
        }

        /*
            Time complexity: O(1)
        */
        public void Clear()
        {
            current = -1;
        }

    }
}
