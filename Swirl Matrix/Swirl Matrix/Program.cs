using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swirl_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Row of Matrix: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter Column of Matrix: ");
            int col = int.Parse(Console.ReadLine());

            int counter = 0;
            Console.Write("Enter the Length of the Array: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                counter++;
                array[i] = counter;
            }

            counter = 0;
            int lastPlace = 0;
            int place = 0;
            int[,] myArray = new int[row, col];
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    myArray[j, i] = array[j];
                    lastPlace = j;
                    counter = j;
                    counter++;
                }
                for (int k = 1, m = counter; k < row ; k++, m++)
                {
                    myArray[lastPlace, k] = array[m];
                    place = k;
                    counter = m;
                    counter++;
                }
                for (int p = place - 1; p >= 0; p--)
                {
                    myArray[p, col - 1] = array[counter];
                    counter++;
                    place = counter;
                }
                for (int q = row - 2; q >= 1; q--)
                {
                    myArray[0, q] = array[place];
                    place++;
                    counter = place;
                }
                for (int r = 1; r < row - 1; r++)
                {
                    myArray[r, 1] = array[counter];
                    counter++;
                    place = counter;
                }
                for (int s = col - 2; s >= 1; s--)
                {
                    myArray[s, row - 2] = array[place];
                    place++;
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(" {0}", myArray[i, j]);
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
