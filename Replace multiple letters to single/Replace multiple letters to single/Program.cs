using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace_multiple_letters_to_single
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            string text = "aaaaabbbbbcdddeeeedssaa";
            CheckChar(text);
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }

        static void CheckChar(string text)
        {
            char tmp = ' ';
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != tmp)
                {
                    sb.Append(text[i]);
                    tmp = text[i];
                }
                else
                {
                    continue;
                }

            }
        }

        
        
    }
}
