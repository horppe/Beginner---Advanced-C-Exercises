using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biggest_element_of_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 6, 9, 5, 4, 3, 1, 7, 8, 10 };
            int big = FindBiggest(array);
            PrintArray(array);
            Console.WriteLine("The biggest element of the array is {0}", big);
            Console.ReadKey();
        }
        static void PrintArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }
        static int FindBiggest(int[] array)
        {
            int tmp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > tmp)
                {
                    tmp = array[i];
                }
            }
            return tmp;
        }
    }
}
