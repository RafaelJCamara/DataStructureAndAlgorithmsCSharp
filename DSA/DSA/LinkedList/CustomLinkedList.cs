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

            if (Head == null)
            {
                Tail = node;
            }
            else
            {
                node.Next = Head;
            }

            Head = node;
        }

        /*
            Time Complexity: O(1)
        */
        public void AddLast(int value)
        {
            var node = new CustomNode
            {
                Value = value
            };

            if(Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
        }

        /*
            Time Complexity: O(1)
        */
        public void RemoveFirst()
        {
            if (Head == null) throw new NullReferenceException("No nodes to be removed!");
            var aux = Head;
            Head = Head.Next;
            aux.Next = null;
            if (Head == null) Tail = null;
        }

        /*
            Time Complexity: O(n)
        */
        public void RemoveLast()
        {
            if (Head == null) throw new NullReferenceException("No nodes to be removed!");
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                return;
            }
            CustomNode aux = Head;
            while (aux.Next.Next != null)
            {
                aux = aux.Next;
            }
            aux.Next = null;
            Tail = aux;
        }

        /*
            Time Complexity: O(n)
        */
        public bool Contains(int value)
        {
            var aux = Head;
            while (aux != null)
            {
                if (aux.Value == value) return true;
                aux = aux.Next;
            }
            return false;
        }

        /*
            Time Complexity: O(n)
        */
        public int IndexOf(int value)
        {
            var aux = Head;
            int index = 0;
            while(aux != null)
            {
                if(aux.Value == value) return index;
                index += 1;
                aux = aux.Next;
            }
            return -1;
        }

    }
}
