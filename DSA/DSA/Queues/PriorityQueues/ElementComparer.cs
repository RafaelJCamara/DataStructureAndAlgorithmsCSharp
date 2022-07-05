using System;
namespace DSA.Queues.PriorityQueues
{
    public class ElementComparer : IComparer<Int32>
    {
        public int Compare(int x, int y)
        {
            if (x == y)
            {
                return 0;
            }
            return x - y;
        }
    }
}

