using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_With_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                PrintTriangle(1, i);
            }
            for (int i = n - 1; i >= 1; i--)
            {
                PrintTriangle(1, i);
            }
            Console.ReadKey();
        }
        static void PrintTriangle(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();
        }
    }
    
}
