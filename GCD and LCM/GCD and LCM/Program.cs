using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD_and_LCM
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100;
            int y = 60;
            int counter = 0;
            int f = 0;
            int result = 0;
            int gcd = 0;
            for (int i = 0; i < 1; i++)
            {
                result = x % y;
                if (result == 0)
                {
                    Console.WriteLine("The GCD is " + y);
                    gcd = y;
                    break;
                }
                counter = y % result;
                if (counter == 0)
                {
                    Console.WriteLine("The GCD is " + result);
                    gcd = result;
                    break;
                }
                f = result % counter;
                if (f == 0)
                {
                    Console.WriteLine("The GCD is " + counter);
                    gcd = counter;
                    break;
                }
            }
            int lcm = (x * y) / gcd;
            Console.WriteLine("The LCM is " + lcm);

            Console.ReadKey();
        }
    }
}
