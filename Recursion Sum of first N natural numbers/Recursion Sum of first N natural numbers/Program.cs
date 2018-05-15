using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Sum_of_first_N_natural_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("The Sum of the first {0} Natural numbers is {1}.", n, GenerateSum(n));
            Console.ReadKey();
        }
        static int GenerateSum(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            return n + GenerateSum(n - 1);
        }
    }
}
