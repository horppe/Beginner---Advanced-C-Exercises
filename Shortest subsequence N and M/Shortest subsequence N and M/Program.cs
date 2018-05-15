using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortest_subsequence_N_and_M
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5, m = 16;
            Queue<int> queue = new Queue<int>();
            Queue<int> result = new Queue<int>();
            queue.Enqueue(n);
            for (int i = 1; i <= 5; i++)
            {
                int tmp = queue.Dequeue();
                result.Enqueue(tmp);    //Remember to add Dequeued element to result
                queue.Enqueue(tmp += 1);
                queue.Enqueue(tmp += 2);        //Formular for operation of sequence
                queue.Enqueue(tmp *= 2);
            }
            int count = queue.Count;
            for (int i = 0; i < count; i++)
            {   //Add the rest of the elements of queue into result
                result.Enqueue(queue.Dequeue());
            }

            int temp = result.Dequeue();
            while (true)
            {
                if (temp <= m)
                {   //Print only the values that fall within the appropriate range
                    Console.Write("{0} ", temp);
                    if (temp == m)
                    {
                        break;
                    }
                    temp = result.Dequeue();
                }
                
            }
            Console.ReadKey();
        }
    }
}
