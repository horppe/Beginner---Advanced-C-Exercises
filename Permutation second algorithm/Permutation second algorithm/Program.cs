using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutation_second_algorithm
{
    class Program
    {
        static int[] array;
        static void Main(string[] args)
        {
            Console.Write("Enter N Perm: ");
            int n = int.Parse(Console.ReadLine());
            array = new int[n];
            for (int i = 1; i <= n; i++)
            {
                array[i - 1] = i;
            }
            Permutation(n - 1);
            Console.ReadKey();
        }

        static void Permutation(int n)
        {
            if (n == 0)
            {
                PrintArray(array);
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int tmp = array[i];
                    array[i] = array[n];
                    array[n] = tmp;
                    Permutation(n - 1);
                    tmp = array[i];
                    array[i] = array[n];
                    array[n] = tmp;
                }
            }
        }

        static void PrintArray(int[] array)
        {
            Console.Write("(");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
    }
}
