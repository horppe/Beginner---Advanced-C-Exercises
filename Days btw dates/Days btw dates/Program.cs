using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Days_btw_dates
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] formats = { "dd/MM/yy", "dd-MM-yy", "dd MM yy", "dd/MM/yyyy", "d.MM.yy" };
                Console.WriteLine("This program calculates the number of days between two input dates.");
                Console.Write("Enter first date: ");
                DateTime dayOne = DateTime.ParseExact(Console.ReadLine(), formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
                Console.Write("Enter second date: ");
                DateTime dayTwo = DateTime.ParseExact(Console.ReadLine(), formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
                int count = 0;
                DateTime tmpDate = dayOne;
                while (tmpDate != dayTwo)
                {
                    tmpDate = tmpDate.AddDays(1);
                    count++;
                }
                Console.WriteLine("There are {0} days between {1: dd/MM/yyyy} and {2: dd/MM/yyyy}", count, dayOne, dayTwo);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Parsing failed.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format is not supported by the program.");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
