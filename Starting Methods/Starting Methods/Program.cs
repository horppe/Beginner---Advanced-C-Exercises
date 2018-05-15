using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starting_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter No 1: ");
            int no1 = int.Parse(Console.ReadLine());
            Console.Write("Enter No 2: ");
            int no2 = int.Parse(Console.ReadLine());
            Console.Write("Enter No 3: ");
            int no3 = int.Parse(Console.ReadLine());
            int max1 = GetMax(no1, no2);
            int max2 = GetMax(max1, no3);

            Console.WriteLine("The Maximum number is {0}", max2);
            Console.ReadKey();
        }
        static int GetMax(int number1, int number2)
        {
            if (number1 > number2)
            {
                return number1;
            }
            else if (number2 > number1)
            {
                return number2;
            }
            else
            {
                return 0;
            }
        }
    }
}
