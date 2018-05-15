using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Number_in_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("{0,15:D}", x);
            Console.WriteLine("{0,15:C}",x);
            Console.WriteLine("{0,15:E}", x);
            Console.WriteLine("{0,15:X}", x);

            Console.ReadKey();
       
        }
    }
}
