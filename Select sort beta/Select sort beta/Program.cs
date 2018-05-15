using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select_sort_beta
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 5, 7, 8, 9, 6, 4, 3, 1 };
            int pos = 0, temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                pos = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[pos])
                    {
                        pos = j;
                    }
                }
                temp = array[pos];
                array[pos] = array[i];
                array[i] = temp;
            }

            Console.Write("Enter Item: ");
            int item = int.Parse(Console.ReadLine());
            int min = 0;
            int max = array.Length - 1;
            int mid = 0;
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (item < array[mid])
                {
                    max = mid - 1;
                }
                if (item > array[mid])
                {
                    min = mid + 1;
                }
                if (item == array[mid])
                {
                    Console.Write(array[mid] + " is the item.");
                    break;
                }
            }


            Console.ReadLine();
        }
    }
}
