using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sub_Matrix_of_3_x_3_in_N_by_M
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter M: ");
            int m = int.Parse(Console.ReadLine());
            int[,] array = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Enter element {0} : {1}: ", i, j );
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int bestRow = 0;
            int bestCol = 0;
            int max = 0;
            int bestMax = 0;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < m - 2; j++)
                {
                    max = array[i, j] + array[i, j + 1] + array[i, j + 2] +
                        array[i + 1, j] + array[i + 1, j + 1] + array[i + 1, j + 2] +
                        array[i + 2, j] + array[i + 2, j + 1] + array[i + 2, j + 2];
                    if (max > bestMax)
                    {
                        bestMax = max;
                        bestRow = i;
                        bestCol = j;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = bestRow; i < (bestRow + 2); i++)
            {
                for (int j = bestCol; j < (bestCol + 2); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("The Max Sum is {0}", bestMax);

            Console.ReadKey();
        }
    }
}
