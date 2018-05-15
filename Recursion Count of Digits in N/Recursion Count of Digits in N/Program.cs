using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Count_of_Digits_in_N
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 123456;
            Console.Write("The number {0} has ", n);
            int result = CountDigits(n);
            Console.Write("a count of {0} numbers", result);
            Console.ReadKey();
        }
        static int CountDigits(int n)
        {
            int index = 0;
            if (n <= 0)
            {
                return 0;
            }
            index++;
            return index + CountDigits(n / 10);



        }
    }
}
