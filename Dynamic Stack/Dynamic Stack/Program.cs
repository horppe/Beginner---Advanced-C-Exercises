using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicStack<int> stack = new DynamicStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(4);
            stack.Push(10);
            stack.Pop();
            int temp = stack.Peek;
            stack.Clear();
            Console.ReadKey();
        }
    }

    class DynamicStack<T>
    {
        Node tail;
        private int count;
        public int Count { get { return count; } }
        
        class Node
        {   //The node to be linked
            public Node prevNode;
            public T element;
            public Node(T item)
            {   //Node default Constructor
                element = item;
                prevNode = null;
            }

            public Node(T item, Node tail)
            {   //Node second Constructor to link new element with tail
                element = item;
                this.prevNode = tail;
            }
        }

       public DynamicStack()
        {   //Dynamic stack constructor
            tail = null;
            count = 0;
        }

        public void Push(T item)
        {   //Add element by point this.prevNode to tail, and point new tail at new Node
            if (count < 1 || count == 0)
            {
                tail = new Node(item);
            }
            else
            {   //Call to the second constructor of the Node class
                Node newNode = new Node(item, tail);
                tail = newNode;     //Make newNode the new Tail
            }
            count++;
        }

        public T Pop()
        {   //Remove the tail and point new tail at prevNode
            Node extracted = tail;
            tail = tail.prevNode;
            count--;
            return extracted.element;   //return the removed element
        }

        public T Peek
        {
            get { return tail.element; }
        }

        public void Clear()
        {
            tail = null;
            count = 0;
        }
    }
}
