using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 1st Number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd Number: ");
            int b = int.Parse(Console.ReadLine());
            int math = Math.Max(a, b);
            Console.WriteLine("The greater of the 1st and 2nd number is {0}, respectively.", math);
            Console.ReadKey();
        }
    }
}
