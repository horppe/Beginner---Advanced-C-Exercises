using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Power_of_N
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("To the power of: ");
            int m = int.Parse(Console.ReadLine());
            int sum = GetNPower(n, m);
            Console.WriteLine("{0} is the result", sum);
            Console.ReadKey();
        }
        static int GetNPower(int n, int pos)
        {
            if (pos == 0)
            {
                return 1;
            }
            return n * GetNPower(n, pos - 1);
        }
    }
}
