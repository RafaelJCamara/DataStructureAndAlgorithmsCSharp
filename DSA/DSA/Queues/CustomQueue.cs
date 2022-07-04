using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Queues
{
    public class CustomQueue
    {
        private const int QueueSize = 50;
        public int Front { get; private set; }
        public int Back { get; private set; }
        public int Count { get; private set; }
        private int[] _queue;
        public int[] Queue
        {
            get { return _queue; }
        }


        public CustomQueue()
        {
            _queue = new int[QueueSize];
        }

        /*
            Time Complexity: O(1)
         */
        public void Enqueue(int value)
        {
            if (IsQueueFull()) throw new InvalidOperationException("Queue is full!");
            _queue[Back] = value;
            Back = (Back + 1) % QueueSize;
            Count += 1;
        }

        /*
            Time Complexity: O(1)
        */
        public void Dequeue()
        {
            if (IsQueueEmpty()) throw new InvalidOperationException("Queue is empty!");
            Front = (Front + 1) % QueueSize;
            Count -= 1;
        }

        /*
            Time Complexity: O(1)
        */
        public int Peek()
        {
            if (IsQueueEmpty()) throw new InvalidOperationException("Queue is empty!");
            return _queue[Front];
        }

        /*
            Time Complexity: O(1)
        */
        public bool IsQueueEmpty()
        {
            return Count==0;
        }

        /*
            Time Complexity: O(1)
        */
        public bool IsQueueFull()
        {
            return Count==QueueSize;
        }


    }
}
