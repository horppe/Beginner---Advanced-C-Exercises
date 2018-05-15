using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularQueue<int> cq = new CircularQueue<int>();
            cq.Enqueue(1);
            cq.Enqueue(2);
            cq.Enqueue(3);
            cq.Enqueue(4);
            cq.Enqueue(5);
            for (int i = 0; i < 20; i++)
            {
                cq.Enqueue(9);
            }
            int tt = cq.Count;
            int temp = cq.Dequeue();
            Console.ReadKey();
        }
    }

    class CircularQueue<T>
    {
        private T[] array;
        private int count;
        int maxCapacity = 4;
        public CircularQueue()
        {
            array = new T[maxCapacity];
            count = 0;
        }
        
        public int Count
        {
            get { return count; }
        }

        public void Enqueue(T item)
        {
            IncreaseSizeIfLow();
            array[count] = item;
            count++;
        }

        public T Dequeue()
        {
            T tempElement = array[0];
            for (int i = 0; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[count - 1] = default(T);
            count--;
            return tempElement;
        }

        private void IncreaseSizeIfLow()
        {
            if (count == maxCapacity)
            {
                T[] tempArray = new T[count];
                Array.Copy(array, tempArray, count);
                maxCapacity = count * 2;
                array = new T[maxCapacity];
                Array.Copy(tempArray, array, count);
            }
            else
            {
                return;
            }
        }
        public T Peek()
        {
            return array[0];
        }
    }
}
