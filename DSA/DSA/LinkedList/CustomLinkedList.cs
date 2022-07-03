using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.LinkedList
{
    public class CustomLinkedList
    {
        public CustomNode Head { get; set; }
        public CustomNode Tail { get; set; }

        /*
            Time Complexity: O(1)
         */
        public void AddFirst(int value)
        {
            var node = new CustomNode
            {
                Value = value
            };
            
            if(Head == null)
            {
                Tail = node;
            }
            else
            {
                node.Next = Head;
            }
            Head = node;
        }

        //AddLast
        //RemoveFirst
        //RemoveLast
        //Contains
        //IndexOf
    }
}
