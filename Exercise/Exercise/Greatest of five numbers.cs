using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter First Number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter Third Number: ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("Enter Fourth Number: ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Enter Fifth Number: ");
            int e = int.Parse(Console.ReadLine());
            if (((a > b) && (a > c)) & ((a > d) && (a > e)))
            {
                Console.WriteLine("The greatest number is {0}", a);
            }
            else if (((b > a) && (b > c)) & ((b > d) && (b > e)))
            {
                Console.WriteLine("The greatest number is {0}", b);
            }
            else if (((c > a) && (c > b)) & ((c > d) && (c > e)))
            {
                Console.WriteLine("The greatest number is {0}", c);
            }
            else if (((d > a) && (d > b)) & ((d > c) && (d > e)))
            {
                Console.WriteLine("The greatest number is {0}", d);
            }
            else if (((e > a) && (e > b)) & ((e > c) && (e > d)))
            {
                Console.WriteLine("The greatest number is {0}", e);
            }
            Console.ReadKey();
        }
    }
}
