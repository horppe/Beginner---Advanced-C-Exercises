using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Enter Number of Elements: ");
            int n = int.Parse(Console.ReadLine());*/
            int[] array = { 3, 4, 1, 9, 7, 5, 2, 6, 8 };
            int counter = 0;
            int min = 0;
            int max = array.Length - 1;
            int mid = (min + max) / 2;
            //Console.Write("Enter the Search item: ");
            //int item = int.Parse(Console.ReadLine());
            /*for (int i = 0; i < array.Length; i++)
            {
                array[i] = ++counter;
            }*/
            int temp = 0;
            counter = 0;
            int pos = 0;
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

            /*while (min < max)
            {
                mid = (min + max) / 2;
                
                if (item > array[mid])
                {
                    min = mid + 1;
                }
                else if(item < array[mid])
                {
                    max = mid - 1;
                }
                if (item == array[mid])
                {
                    Console.Write(array[mid] + " is the item.");
                    break;
                }

            }*/

            Console.ReadKey();
        }
    }
}
