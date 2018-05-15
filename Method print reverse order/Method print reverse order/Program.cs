using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_print_reverse_order
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number: ");
            string n = Console.ReadLine();
            PrintReverse(n);
            Console.ReadKey();
        }
        static void PrintReverse(string number)
        {
            Console.Write("The reverse is ");
            for (int i = number.Length - 1; i >= 0; i--)
            {
                Console.Write(number[i]);
            }
        }
    }
}
