using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_and_K_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            for (int row = 1; row <= n; row++)
            {
                for (int col = row; col <= row + (n - 1); col++)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
