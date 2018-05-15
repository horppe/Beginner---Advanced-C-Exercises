using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_consecutive_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 1, 2, 2, 2, 2, 2, 2, 1 };
            List<int> other = new List<int>();
            List<int> counter = new List<int>();
            int holder = 0;
            for (int a = 0; a < array.Length - 1; a++)
            {
                if (array[a] == array[a + 1])
                {
                    for (int b = a; b < array.Length; b++)
                    {
                        counter.Add(array[b]);

                        if (array[b] != array[b + 1])
                        {
                            holder = b;
                            for (int i = counter.Count - 1; i >= 0; i--)
                            {
                                
                                other.Add(counter[i]);
                                counter.Remove(counter[i]);
                            }
                            break;
                        }
                    }
                }
                break;
            }
            for (int c = holder; c < array.Length; c++)
            {
                if (array[c] == array[c + 1])
                {
                       for (int i = c; i < array.Length - 1; i++)
                       {
                           counter.Add(array[i]);
                        if (i == array.Length - 1)
                        {
                            counter.Add(array[i + 1]);
                        }
                           if (array[i] != array[i + 1])
                           {
                               break;
                           }
                       }
                       for (int a = other.Count - 1; a >= 0; a--)
                       {
                            if (counter.Count > other.Count)
                            {
                                 other.Remove(other[a]);
                            }
                       }
                    for (int i = 0; i < counter.Count; i++)
                    {
                        other.Add(counter[i]);
                    }
                }
                if (other.Count == counter.Count)
                {
                    break;
                }
            }

            for (int i = 0; i < other.Count; i++)
            {
                Console.Write(other[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
