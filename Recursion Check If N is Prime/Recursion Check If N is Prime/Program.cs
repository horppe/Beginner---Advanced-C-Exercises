using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Check_If_N_is_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program to check if a number is a Prime number");
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            CheckPrime(n, 2);
            Console.ReadKey();
        }
        static void CheckPrime(int n, int pos)
        {
            if (pos == n )
            {
                Console.WriteLine("{0} is a Prime number", n);
                return;
            }
            if (n % pos == 0)
            {
                Console.WriteLine("{0} is not a Prime number", n);
                return;
            }
            else
            {
                CheckPrime(n, pos + 1);
            }
            
        }
    }
}
