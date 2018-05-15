using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Nth Fibonacci: ");
            int n = int.Parse(Console.ReadLine());
            int[] fibArr = new int[n];
            fibArr[0] = 1;
            fibArr[1] = 1;
            int[] number = Fib(fibArr, n, 2);
            Console.Write("The {0}th Fibonacci sequence is: ", n);
            PrintArray(number);
            Console.WriteLine("{0} is the {1}th Fibonacci number.", number[n - 1], n);
            Console.ReadKey();
        }
        static int[] Fib(int[] array, int n, int pos)
        {
            if (pos == n)
            {
                return array;
            }
            else
            {
                array[pos] = array[pos - 1] + array[pos - 2];
                return Fib(array, n, pos + 1);
            }
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
