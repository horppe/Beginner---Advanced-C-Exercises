using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            Queue<int> queue = new Queue<int>();
            Queue<int> result = new Queue<int>();
            queue.Enqueue(n);
            int tmp = 2;
            for (int i = 0; i <= 17; i++)
            {
                int k = queue.Dequeue();
                queue.Enqueue(k + 1);
                queue.Enqueue((2 * k) + 1);     //This is the formular for the sequence
                queue.Enqueue(k + 2);
                result.Enqueue(k);  //Add the elements removed into the result Queue
            }
            while (true)
            {
                result.Enqueue(queue.Dequeue());
                if (queue.Count <= 0)
                {
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
