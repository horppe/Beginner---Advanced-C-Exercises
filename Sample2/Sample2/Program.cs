using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((30 % 5 == 0) && ( 30 % 7 == 0))
            {
                Console.WriteLine("The number can be divided by 5 and 7");
            }
            else
            {
                Console.WriteLine("The number cannot be divided by 5 and 7");
            }
            Console.ReadKey();
        }
    }
}
