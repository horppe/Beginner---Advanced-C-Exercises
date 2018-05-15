using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Testing_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 1, 2, 3, 1, 1, 1, 1};
            List<int> other = new List<int>();
            for (int i = 0; i < array.Length - 2; i++)
            {
                if (array[i] == array[i + 1])
                {
                    other.Add(array[i]);
                    other.Add(array[i + 1]);
                    if (array[i] == array[i + 2])
                    {
                        other.Add(array[i + 2]);
                    }
                    for (int a = 0; a < other.Count; a++)
                    {
                        if (array[a] > other[a])
                        {
                            for (int b = 0; b < other.Count; b++)
                            {
                                other.Remove(other[b]);
                                break;
                            }
                        }
                    }
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

