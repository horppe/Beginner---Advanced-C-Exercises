using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Integers seperated by space: ");
            string input = Console.ReadLine();
            string[] value = input.Split(' ');

            for (int i = 0; i < value.Length; i++)
            {
                Console.WriteLine(value[i]);
            }
            Console.ReadKey();
        }
    }
}
