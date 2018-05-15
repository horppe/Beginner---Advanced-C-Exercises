using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Parse_Date_and_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Date and Time \nday.month.year hour:minutes:seconds: ");
            DateTime time = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            time = time.AddHours(6);
            time = time.AddMinutes(30);
            Console.WriteLine("The time is {0: d/MM/yyyy HH:mm:ss}", time);
            Console.ReadKey();
        }
    }
}
