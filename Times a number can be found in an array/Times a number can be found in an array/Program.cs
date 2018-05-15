using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Times_a_number_can_be_found_in_an_array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter No. to search: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = { 3, 4, 5, 6, 7, 8, 2, 4, 5, 1, 9, 0, 8, 7, 5, 3, 1, 2, 4, 6, 8, 9};
            Console.WriteLine("The number {0} is present {1} times.", n, FindNumbers(array, n));

            Console.ReadKey();
        }
        static int FindNumbers( int[] arrayi, int search)
        {
            int count = 0;
            for (int i = 0; i < arrayi.Length; i++)
            {
                if (arrayi[i] == search)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
