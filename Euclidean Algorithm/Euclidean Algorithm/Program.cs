using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidean_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter X: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter Y: ");
            int y = int.Parse(Console.ReadLine());
            while ((x != 0) && (y != 0))
            {
                if (x > y)
                {
                    x %= y;
                }
                else
                {
                    y %= x;
                }
            }

            if (x == 0)
            {
                Console.WriteLine(y + " is the GCD.");
            }
            else
            {
                Console.WriteLine(x + " is the GCD.");
            }
            Console.ReadKey();
        }
    }
}
