using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeroes_of_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the value of N: ");
            long n = int.Parse(Console.ReadLine());
            long nn = n;
            for (int i = 1; i < n; i++)
            {
                nn *= i;
            }
            int counter = 0;
            while (nn % 10 == 0)
            {
                nn /= 10;
                counter++;
            }
            
            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
