using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter N: ");
            //int n = int.Parse(Console.ReadLine());
            int[] array = new int[10] { 2, 3, 5, 6, 9, 8, 1, 4, 7, 10 };
            int min = 0;
            int temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[min] > array[j])
                    {
                        min = j;
                    }
                }

                temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }

            for (int a = 0; a < array.Length; a++)
            {
                Console.Write(array[a] + " ");
            }

            Console.ReadKey();
        }
    }
}
