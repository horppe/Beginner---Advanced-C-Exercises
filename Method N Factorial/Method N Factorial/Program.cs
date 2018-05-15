using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Method_N_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine("The value is: {0}", CalculateFactorial(n));
            Console.ReadKey();
        }
        static BigInteger CalculateFactorial(BigInteger number)
        {
            BigInteger sum = 1;
            for (BigInteger i = number; i >= 1; i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
