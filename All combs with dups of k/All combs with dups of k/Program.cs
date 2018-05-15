using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_combs_with_dups_of_k
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];
            Console.WriteLine("Recursive algorithm:");
            GetCombinations(array, n, 0);
            Console.WriteLine();
            Console.WriteLine("Iterative algorithm:");
            ItGetComb(array, n);
            Console.ReadKey();
        }

        static void ItGetComb(int[] array, int n)
        {
            int pos;
            InitiateValue(array);
            while (true)
            {
                if (ValidateIndex(array))
                {
                    PrintArray(array);
                }
                pos = array.Length - 1;
                array[pos] = array[pos] + 1;      //Iterative algorithm
                while (array[pos] > n)
                {
                    array[pos] = 1;
                    pos--;
                    if (pos < 0)
                    {
                        return;
                    }
                    array[pos] = array[pos] + 1;
                }
            }
        }

        static void GetCombinations(int[] array, int n, int pos)
        {
            if (pos == array.Length) 
            {
                if (ValidateIndex(array))  //Return the validate bool value
                {
                    PrintArray(array);
                }
                else
                {
                    return;
                }
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    array[pos] = i;
                    GetCombinations(array, n, pos + 1);
                }
            }
        }

        static void PrintArray(int[] array)
        {
            Console.Write("(");
            for (int i = 0; i < array.Length; i++)     //Print current combination
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

        static bool ValidateIndex(int[] array)
        {
            int swt = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] <= array[i + 1])               //Check if the array is proper before printing
                {
                    swt = 1;
                }
                else
                {
                    swt = 2;
                    break;
                }
            }
            if (swt == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void InitiateValue(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1;
            }
        }

    }
}
