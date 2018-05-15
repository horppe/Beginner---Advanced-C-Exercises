using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymials_Addition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(Ax^2 + x - B) + (x - 1)");
            Console.Write("A = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("B = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("X = ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("The sum is {0}", AddArrays(a, b, x));
            Console.ReadKey();
        }
        static int AddArrays(int a, int b, int x)
        {
            int xp = x * x;
            int firSum = (a * xp) + (x - b);
            int sum = firSum + (x - 1);
            return sum;
        }

    }
}
