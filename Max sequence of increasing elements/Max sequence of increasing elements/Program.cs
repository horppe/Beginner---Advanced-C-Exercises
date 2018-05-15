using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_sequence_of_increasing_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 9, 6, 2, 7, 4, 7, 6, 5, 8, 4 };
            List<int> counter = new List<int>();
         
            int start = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array.Min())
                {
                    start = array[i];
                        break;
                }
                else
                {
                    continue;
                }
            }
            counter.Add(array[start]);
            for (int a = start; a < array.Length - 1; a++)
            {
                for (int b = start + 1; b < array.Length - 1; b++)
                {
                    if ((array[a] == (array[b] - 1)) || (array[a] == (array[b] - 2)))
                    {
                        counter.Add(array[b]);
                        a = array[array[b]];
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            for (int i = 0; i < counter.Count; i++)
            {
                Console.Write("{0} ", counter[i]);
            }
            Console.ReadKey();
        }
    }
}
