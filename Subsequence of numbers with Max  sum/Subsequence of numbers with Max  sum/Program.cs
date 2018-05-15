using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsequence_of_numbers_with_Max__sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            Console.Write("Enter the Sequence Number: ");
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int index = 0;
            int element = 0;
            int temp = 0;

            for (int j = 0; j < array.Length - n; j++)
            {
                counter = 0;
                for (int i = j; i < j + n; i++)
                {
                    counter += array[i];
                    temp = counter;

                    if (temp > index)
                    {
                        index = temp;
                        element = j;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = element; i < element + n; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.Write("Total is {0}", index);
            
            Console.ReadKey();
        }
    }
}
