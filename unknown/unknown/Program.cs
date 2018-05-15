using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unknown
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number 1: ");
            string str = Console.ReadLine();
            int a;
            bool ps1 = Int32.TryParse(str, out a);
            Console.WriteLine("Enter Number 2: ");
            int b;
            bool ps2 = Int32.TryParse(str, out b);
            Console.Write("Enter Number 3: ");
            int c;
            bool ps3 = Int32.TryParse(str, out c);
            Console.Write("Enter Number 4: ");
            int d;
            bool ps4 = Int32.TryParse(str, out d);
            Console.Write("Enter Number 5: ");
            int e;
            bool ps5 = Int32.TryParse(str, out e);
            int sum = a + b + c + d + e;
            Console.WriteLine("The sum of all the numbers is = {0}", sum);
            Console.ReadKey();
        }
    }
}
