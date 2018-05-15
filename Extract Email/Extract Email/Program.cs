using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Extract_Email
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Please contact us by phone (+001 222 222 222) or" +
                            "by email at example@gmail.com or at test.user@yahoo.co.uk." +
                            " This is not email: test@test. This also: @gmail.com. Neither this: a@a.b.";
            MatchCollection collect = Regex.Matches(text, @"[A-Za-z\._]+@[a-z]+\.[a-z]{2,}\.?[a-z]*");
            Console.ReadKey();
        }
    }
}
