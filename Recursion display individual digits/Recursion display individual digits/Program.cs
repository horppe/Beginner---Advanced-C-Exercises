using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_display_individual_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            string n = Console.ReadLine();
            PrintDigits(n, 0);
            Console.ReadKey();
        }
        static void PrintDigits(string n, int index)
        {
            if (index == n.Length)
            {
                return;
            }
            Console.Write(" {0}", n[index]);
            PrintDigits(n, index + 1);
        }
    }
}
