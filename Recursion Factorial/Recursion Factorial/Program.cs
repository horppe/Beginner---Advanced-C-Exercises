using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N!: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("The factorial of {0} is {1}", n, Factorial(n));
            Console.ReadKey();
        }

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
