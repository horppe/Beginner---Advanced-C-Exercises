using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number 1: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter Number 2: ");
            int b = int.Parse(Console.ReadLine());
            int c = b;
            if (a > b)
            {
                a = c;
            }
            else
            {
                Console.WriteLine(a + " and " + b);
            }
            Console.ReadKey();

        }
    }
}
