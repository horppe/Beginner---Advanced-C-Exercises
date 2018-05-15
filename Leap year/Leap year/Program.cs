using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap_year
{
    class Program
    {
        static void Main(string[] args)
        {
            LeapYear result = new LeapYear();
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            if (result.IsLeap(year))
            {
                Console.WriteLine("{0} is a leap year", year);
            }
            else
            {
                Console.WriteLine("{0} is not a leap year", year);
            }
            Console.ReadKey();
        }
    }
    class LeapYear
    {
        public bool IsLeap(int year)
        {
            return DateTime.IsLeapYear(year);
        }
    }
}
