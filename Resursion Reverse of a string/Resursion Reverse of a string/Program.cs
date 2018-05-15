using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resursion_Reverse_of_a_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input string: ");
            string word = Console.ReadLine();
            int n = word.Length;
            GetReverse(word, n - 1);
            Console.ReadKey();
        }
        static void GetReverse(string word,int pos)
        {
            if (pos < 0)
            {
                return;
            }
            else
            {
                Console.Write(word[pos]);
                GetReverse(word, pos - 1);
            }
        }
    }
}
