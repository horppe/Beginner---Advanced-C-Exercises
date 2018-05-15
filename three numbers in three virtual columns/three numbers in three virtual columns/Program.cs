using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace three_numbers_in_three_virtual_columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int numA = 9;
            float numB = 3.123456f;
            float numC = -1.23456f;
            Console.WriteLine("{0, -10:X}{1, -10:F2}{2, -10:F2}", numA, numB, numC);
            Console.ReadKey();

        }
    }
}
