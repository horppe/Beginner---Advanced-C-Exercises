using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_in_Descending_order
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 6, 9, 5, 4, 3, 1, 7, 8, 10 };
            Console.Write("The unsorted array is: ");
            PrintArray(array);
            Console.Write("The sorted array in Descending order is: ");
            PrintArray(Sort(array));
            Console.ReadKey();
        }
        static int[] Sort(int[] array)
        {
            int tmp = 0;
            int tmp2 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                tmp = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[tmp] < array[j])
                    {
                        tmp = j;
                    }
                }
                tmp2 = array[i];
                array[i] = array[tmp];
                array[tmp] = tmp2;
            }
            return array;
        }
        static void PrintArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
