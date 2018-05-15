using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_char_string_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string of at least 20 chars: ");
            string str = Console.ReadLine();
            if (str.Length < 20)
            {
                StringBuilder sb = new StringBuilder();
                int temp = 20 - str.Length;
                string format = String.Format("({0}) [a-z] {1}", str, temp);
                for (int i = 0; i < temp; i++)
                {
                    sb.Append("*");
                }
                string replace = String.Format("{0}{1}", str, sb.ToString());
                Console.WriteLine(replace);
            }
            else
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }
    }
}
