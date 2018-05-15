using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_matrix_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of Rows: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of Columns: ");
            int col = int.Parse(Console.ReadLine());

            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            List<int> array = new List<int>(16);
            int[,] myArray = new int[row, col];
            int counter = 1;
            int place = 0;

            for (int i = 0; i < list.Length; i++)
            {
                array.Add(list[i]);
            }

            counter = 0;

            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = i, x = 0; j < row; j++, x++)
                {
                    myArray[j, x] = array[counter];
                    counter++;
                    place = counter;
                }
            }

            for (int i = 1; i < row; i++)
            {
                for (int j = i, k = 0; j < row; j++, k++)
                {
                    myArray[k, j] = array[place];
                    place++;
                }
            }

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.Write(myArray[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
