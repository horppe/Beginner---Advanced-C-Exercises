using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin_to_Dec_with_Horner
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bin = { 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0 };
            int a = 1, temp = bin[0];
            List<int> count = new List<int>();
            while (a < bin.Length)
            {
                temp = (temp * 2) + bin[a++];
            }
            Console.WriteLine("Conversion to Decimal by Horner scheme.");
            Console.WriteLine("Equals {0}", temp);

            Console.ReadKey();
        }
    }
}
