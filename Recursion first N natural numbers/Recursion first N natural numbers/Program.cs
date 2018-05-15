using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_first_N_natural_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            PrintNumbers(n, 1);
            Console.ReadKey();
        }
        static void PrintNumbers(int n, int number)
        {
            if (number > n)
            {
                return;
            }
            Console.Write(number + " ");
            PrintNumbers(n, number + 1);
        }
    }
}
