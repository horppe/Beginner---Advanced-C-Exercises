using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross_Multiplying_Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Row: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter Column: ");
            int col = int.Parse(Console.ReadLine());
            int[,] array = new int[row, col];
            int[,] myArray = new int[row, col];
            int counter = 1;

            Console.Write("Enter number of Elements: ");
            int element = int.Parse(Console.ReadLine());
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    array[i, j] = counter++;         // I could make it read from console by making it equal to int.Parse(Console.ReadLine()); 
                    myArray[i, j] = element--;
                }
            }

            int[,] result = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = array[i, j] * myArray[i, j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
