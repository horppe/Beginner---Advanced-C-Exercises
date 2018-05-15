using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Print_odd_or_even_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter M: ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Even numbers between the Range of {0} to {1} are:", n, m);
            PrintEvenNumber(n, m);
            Console.WriteLine();
            Console.WriteLine("Odd numbers between the Range of {0} to {1} are:", n, m);
            PrintOddNumber(n, m);
            Console.ReadKey();
        }
        static void PrintEvenNumber(int start, int end)
        {
            if (start > end)
            {
                return;
            }
            if (start % 2 == 0)
            {
                Console.Write(" {0} ", start);
            }
            PrintEvenNumber(start + 1, end);
        }
        static void PrintOddNumber(int start, int end)
        {
            if (start > end)
            {
                return;
            }
            if (start % 2 != 0)
            {
                Console.Write(" {0} ", start);
            }
            PrintOddNumber(start + 1, end);
        }
    }
}
