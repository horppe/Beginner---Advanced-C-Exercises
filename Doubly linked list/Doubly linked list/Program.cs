using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoublyLinkedList<int> list = new DoublyLinkedList<int>();
                list.Add(4);
                list.Add(2);
                list.Add(7);        //Testing the Doubly Linked list
                list.Add(10);
                list.Insert(0, 56);
                list.Add(5);
                list.Add(8);
                list.Add(1);
                list.Add(3);
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i] > list[j])
                        {
                            int tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }
                    }
                }
                Console.ReadKey();
            }
            catch (Exception except)
            {
                Console.WriteLine(except.Message);
            }
            
        }
    }

    class DoublyLinkedList<T> where T: IComparable<T>
    {
        private int count;
        class Node
        {   //Node contains the element T stored in the object
            //as well as pointers to the previous and next objects
            public Node prevNode = null;
            public T element { get; set; }
            public Node nextNode = null;
            public Node(T element)
            {
                this.element = element;
                nextNode = null;
            }
            public Node(T element, Node prevNode)
            {   //This second constructor is called only from inside the Object itself
                //to link the tail to the newly added element/object of the list, and
                //also link the new tail to the old tail
                this.element = element;
                prevNode.nextNode = this;
                this.prevNode = prevNode;
            }
            
        }
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }
        private Node head;  //Reference holder for the head and tail of the linked list
        private Node tail;  //which are means to traverse the list.

        public int Count
        {
            get { return count; }
        }

        public void Add(T element)
        {
            if (head == null)
            {   //If the list is already empty, add the new element as the head and tail
                head = new Node(element);
                tail = head;
            }
            else
            {   //else if the list is already initialized, add new element as the tail but linked to the old tail
                Node newNode = new Node(element, this.tail);
                tail = newNode;
            }
            count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            Node tempNode = head;

            if (index == 0)
            {   //if the head is being removed, point the new element at the next element after the head
                //and also make the new element the new head
                head = head.nextNode;
                head.prevNode = null;
            }
            else
            {   //Traverse through the list to get the element(tempNode) to be removed
                int cnt = 0;
                while (cnt < index)
                {
                    tempNode = tempNode.nextNode;
                    cnt++;
                }
                //Make the previous element before tempNode point to the next element after tempNode
                tempNode.prevNode.nextNode = tempNode.nextNode;
            }

            if (tempNode.nextNode == null)
            {   //If the tail was removed, point the new tail at the element before the tail
                tail = tempNode.prevNode;
            }
            count--;
        }

        public int IndexOf(T element)
        {
            Node temp = head;
            int cnt = 0;
            while (cnt <= count)
            {   //Traverse through the list to Match the value reference
                if (Equals(element, temp.element))
                {   //Lasttly return the index where it was found, or return -1
                    return cnt;
                }
                temp = temp.nextNode;
                cnt++;
            }
            return -1;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            Node tmp = head;
            
            if (index == 0)
            {   //If the index is the head, point new element to the head,
                //make the new element the new head 
                Node tempNode = new Node(element);
                tempNode.nextNode = head;
                head.prevNode = tempNode;
                head = tempNode;
            }
            else
            {
                int cnt = 0;
                while (cnt < index)
                {   //Traverse through the list to get value
                    tmp = tmp.nextNode;
                    cnt++;
                }
                Node newNode = new Node(element);
                tmp.prevNode.nextNode = newNode;    //Make the element before the index point to the new element
                newNode.prevNode = tmp.prevNode;    //the new element points the previous element (only in Doubly linked)
                newNode.nextNode = tmp;             //and finally point the new element at the element formerly in this index.
            }
            count++;
        }
        
        public T ElementAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            int counter = 0;
            Node node = head;

            while (counter < index)
            {
                node = node.nextNode;
                counter++;
            }
            return node.element;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }
                return ElementAt(index);
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }
                int counter = 0;
                Node tempValue = head;
                while (counter < index)
                {
                    tempValue = tempValue.nextNode;
                    counter++;
                }
                tempValue.element = value;
            }
        }
    }
}
