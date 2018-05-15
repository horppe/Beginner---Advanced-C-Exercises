using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subset_sum_N
{
    class Program
    {
        static int swt;
        static int[] array = { 2, 3, 1, -1 };

        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < array.Length; i++)
            {
                swt = i + 1;
                int[] myArray = new int[i + 1];
                Subset(myArray, n, i, 0);
            }

            Console.ReadKey();
        }

        static void Subset(int[] myArray, int n,int index, int pos)
        {
            if (pos > index)
            {
                if (Permutation(myArray) && SumIndex(myArray, n))
                {
                    if (swt == myArray.Length)
                    {
                        PrintArray(myArray);
                        swt++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    myArray[pos] = array[i];
                    Subset(myArray, n, index, pos + 1);
                }
            }
        }

        static bool SumIndex(int[] array, int n)
        {
            int tmp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                tmp += array[i];
            }

            if (tmp == n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool Permutation(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] != array[j])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void PrintArray(int[] array)
        {
            Console.Write("(");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
    }
}
