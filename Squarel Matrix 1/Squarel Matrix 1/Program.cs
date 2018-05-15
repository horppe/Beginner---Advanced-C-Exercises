using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squarel_Matrix_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of Rows: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of Columns: ");
            int col = int.Parse(Console.ReadLine());
            int[] array = new int[16];
            int counter = 1;
            for (int i = 0; i < 16; i++)
            {
                array[i] = counter;
                counter++;
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = i; j < array.Length; j += col)
                {
                    Console.Write(array[j] + " ");
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
