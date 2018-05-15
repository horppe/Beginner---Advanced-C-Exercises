using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_subset
{
    class Program
    {
        static int[] list = { 2, 3, 7, 8, 10 };
        static bool[,] array;
        static List<int> values = new List<int>();
        static void Main(string[] args)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            array = new bool[list.Length, n + 1];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, 0] = true;
            }
            DynamicAlgo(n);
            Console.Write("Subset of {0} is: ", n);
            for (int i = 0; i < values.Count; i++)
            {
                Console.Write(values[i] + " ");
            }
            Console.ReadKey();
        }

        static void DynamicAlgo(int n)
        {
            for (int i = 0; i < list.Length; i++)
            {
                GenMatrix(n, i, 1);
            }
            int row = array.GetLength(0), col = array.GetLength(1);
            GetSubset(row - 1, col - 1);
        }

        static void GenMatrix(int n, int row, int column)
        {
            if (column > n)
            {
                return;
            }
            else
            {
                if (column == list[row] && row == 0)
                {
                    array[row, column] = true;
                    GenMatrix(n, row, column + 1);
                    return;
                }
                if (column != list[row] && row == 0)
                {
                    array[row, column] = false;
                    GenMatrix(n, row, column + 1);
                    return;
                }
                if (list[row] > column && row > 0)
                {
                    array[row, column] = array[row - 1, column];
                    GenMatrix(n, row, column + 1);
                    return;
                }
                if (list[row] <= column && row > 0)
                {
                    if (array[row -1, column] == true)
                    {
                        array[row, column] = true;
                        GenMatrix(n, row, column + 1);
                        return;
                    }
                    array[row, column] = array[row - 1, column - list[row]];
                    GenMatrix(n, row, column + 1);
                    return;
                }
            }
        }

        static void GetSubset(int row, int col)
        {
            if (row <= 0 && col <= 0)
            {
                return;
            }
            else
            {
                if (array[row - 1, col] == true)
                {
                    GetSubset(row - 1, col);
                    return;
                }
                else
                {
                    values.Add(list[row]);
                    GetSubset(row, col - list[row]);
                    return;
                }
            }
        }
        
        //To Print the Multidimensional matrix.
        //static void PrintArray(bool[,] array)
        //{
        //    for (int i = 0; i < array.GetLength(0); i++)
        //    {
        //        Console.Write("(");
        //        for (int j = 0; j < array.GetLength(1); j++)     
        //        {
        //            Console.Write(array[i, j]);
        //            if (j < array.GetLength(1) - 1)
        //            {
        //                Console.Write(", ");
        //            }
        //        }
        //        Console.Write(")");
        //        Console.WriteLine();
        //    }
        //}
    }
}
