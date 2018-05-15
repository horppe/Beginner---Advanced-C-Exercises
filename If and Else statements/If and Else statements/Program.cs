using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace If_and_Else_statements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number: ");
            string str = Console.ReadLine();
            int number;
            if (int.TryParse(str, out number))
            {
                Console.WriteLine("You entered the number {0}", number);
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
            Console.ReadKey();
        }
    }
}
