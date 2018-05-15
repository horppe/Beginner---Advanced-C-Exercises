using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();
            deque.Append(1);
            deque.Append(5);
            deque.Append(3);
            deque.Append(7);
            deque.Append(8);
            deque.Append(4);
            deque.Prepend(0);
            deque.Eject();
            deque.Preject();
            deque.Clear();
            Console.ReadKey();
        }
    }

    class Deque<T>
    {
        Node head;
        Node tail;
        private int count;
        class Node
        {
            public Node next;
            public T element;
            public Node prev;
            public Node(T item)
            {   //
                element = item;
                next = null;
                prev = null;
            }
            public Node(T item, Node tail)
            {   //Tail constructor, link current tail.next Node with this.newNode and link newNode.prev with the tail. newNode will become the tail later.
                element = item;
                tail.next = this;
                prev = tail;
                next = null;    //newNode.next points to null because it is the new tail
            }
            public Node(Node head, T item)
            {   //Head constructor, link current head.previous Node with this.newNode and link newNode.next with head. newNode will become the head later.
                element = item;
                head.prev = this;
                next = head;
                prev = null;    //newNode.prev points to null because it is the new head
            }
        }
        public Deque()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Append(T item)
        {
            if (count < 1 || count == 0)
            {
                Node newNode = new Node(item);
                head = newNode;
                tail = head;
            }
            else
            {
                Node newNode = new Node(item, tail);
                tail = newNode;
            }
            count++;
        }

        public void Prepend(T item)
        {
            if (count < 1 || count == 0)
            {
                Node newNode = new Node(item);
                head = newNode;
                tail = head;
            }
            else
            {
                Node newNode = new Node(head, item);
                head = newNode;
            }
            count++;
        }

        public T Eject()
        {
            T tempElement = tail.element;
            tail = tail.prev;
            count--;
            return tempElement;
        }

        public T Preject()
        {
            T tempElement = head.element;
            head = head.next;
            count--;
            return tempElement;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
