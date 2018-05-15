using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_Matrix_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of Rows: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of Columns: ");
            int col = int.Parse(Console.ReadLine());

            int[,] array = new int[row, col];
            int[,] myArray = new int[row, col];
            int counter = 0;

            int place = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    counter++;
                    array[i, j] = counter;
                }
            }

            counter = 0;

            for (int i = counter; i < myArray.GetLength(0); i++)
            {
                for (int j = i; j < myArray.GetLength(1); j++)
                {
                    myArray[j, i] = array[i, j];
                }
                counter = i + 1;
                for (int k = myArray.GetLength(0) - 1; k >= 0; k--)
                {
                    myArray[k, counter] = array[counter, place];
                    place++;
                }
                break;
            }
            counter = 2;
            place = 0;
            for (int i = counter; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    myArray[j, i] = array[i, j];
                }
                counter += 1;
                for (int k = myArray.GetLength(0) - 1; k >= 0; k--)
                {
                    myArray[k, counter] = array[counter, place];
                    place++;
                }
                break;
            }

            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.Write(myArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        
        }
    }
}
