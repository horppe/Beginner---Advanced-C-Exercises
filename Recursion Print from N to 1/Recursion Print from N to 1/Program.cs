using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Print_from_N_to_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            PrintReversal(n, 0);
            Console.ReadKey();
        }
        static void PrintReversal(int n, int tmp)
        {
            if (n < tmp)
            {
                return;
            }
            else
            {
                Console.Write(" {0} ", n);
                PrintReversal(n - 1, tmp);
            }
        }
    }
}
