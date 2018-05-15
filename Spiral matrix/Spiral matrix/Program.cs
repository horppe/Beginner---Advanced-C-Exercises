using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            int counter = 0;

            for (int j = 0; j < n; j++)
            {
                array[0, j] = ++counter;
            }

            for (int i = 1; i < n; i++)
            {
                array[i, n - 1] = ++counter;
            }

            for (int j = n - 2; j >= 0; j--)
            {
                array[n - 1, j] = ++counter;
            }

            for (int i = n - 2; i >= 1; i--)
            {
                array[i, 0] = ++counter;
            }

            for (int j = 1; j < n - 1; j++)
            {
                array[1, j] = ++counter;
            }

            for (int j = n - 2; j >= 1; j--)
            {
                array[n - 2, j] = ++counter;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
