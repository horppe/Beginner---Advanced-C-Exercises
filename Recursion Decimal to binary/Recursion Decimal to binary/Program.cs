using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Decimal_to_binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers do you want to Convert to Binary?");
            Console.Write("Please enter a number: ");
            int pos = int.Parse(Console.ReadLine());
            MainSecond(pos);
        }

        static void MainSecond(int pos)
        {
            if (pos == 0)
            {
                return;
            }
            else
            {
                Console.Write("Enter Number for Conversion to Binary: ");
                int n = int.Parse(Console.ReadLine());
                int[] list = new int[8];
                DecToBin(list, n, 0);
                Console.Write("The conversion of {0} to Binary is: ", n);
                for (int i = list.Length - 1; i >= 0; i--)
                {
                    Console.Write(" {0} ", list[i]);
                }
                Console.WriteLine();
                Console.ReadKey();
                MainSecond(pos - 1);
            }
        }

        static void DecToBin(int[] list, int n, int pos)
        {
            if (n <= 0)
            {
                return;
            }
            else
            {
                if (n % 2 != 0)
                {
                    list[pos] = 1;
                }
                else
                {
                    list[pos] = 0;
                }
                DecToBin(list, n / 2, pos + 1);
            }
        }
    }
}
