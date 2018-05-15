using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_name_of_last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            string n = Console.ReadLine();
            char digit = n[n.Length - 1];
            Console.WriteLine(digit);
            PrintName(NameLastDigit(digit), n);
            Console.ReadKey();
        }

        static string NameLastDigit(int number)
        {
            string name = null;
            switch (number)
            {
                case '1': name = "One"; break;
                case '2': name = "Two"; break;
                case '3': name = "Three"; break;
                case '4': name = "Four"; break;
                case '5': name = "Five"; break;
                case '6': name = "Six"; break;
                case '7': name = "Seven"; break;
                case '8': name = "Eight"; break;
                case '9': name = "Nine"; break;
                case '0': name = "Zero"; break;
                default: name = "Invalid Number"; break;
            }
            return name;
        }
        static void PrintName(string name, string number)
        {
            Console.WriteLine("The last digit of \"{0}\" is \"{1}\".", number, name);
        }
    }
}
