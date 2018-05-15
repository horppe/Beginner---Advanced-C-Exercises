using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regex_parse_url
{
    class Program
    {
        static void Main(string[] args)
        {
            //string url = "http://www.cnn.com/video";
            //string pattern = "://|/";
            //string[] array = Regex.Split(url, pattern);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}
            string text = "C# is not C++ and PHP is not Delphi";
            string[] array = text.Split(' ');
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
