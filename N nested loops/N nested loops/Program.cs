using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_nested_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int[] loops = new int[n];
            NestedLoops(loops, 0);
            Console.ReadKey();
        }

        static void NestedLoops(int[] array, int pos)
        {
            if (pos == array.Length )
            {
                PrintArray(array);
            }
            else
            {
                for (int i = 1; i <= array.Length; i++)
                {
                    array[pos] = i;
                    NestedLoops(array, pos + 1);
                }
            }
        }
        
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }
    }
}
