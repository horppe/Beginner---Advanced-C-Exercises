using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypothenus
{
    class Program
    {
        static void Main(string[] args)
        {
            Hypothenus hyp = new Hypothenus();
            Console.Write("Enter side a: ");
            double a = hyp.GenPower(double.Parse(Console.ReadLine()));
            Console.Write("Enter side b: ");
            double b = hyp.GenPower(double.Parse(Console.ReadLine()));
            double result = hyp.SquareRoot(a + b);
            Console.WriteLine("The Hypothenus of a Right triangle is {0:F1}", result);
            Console.ReadKey();
        }
    }
    class Hypothenus
    {
        public double GenPower(double n)
        {
            return Math.Pow(n, 2);
        }

        public double SquareRoot(double n)
        {
            return Math.Sqrt(n);
        }
    }
}
