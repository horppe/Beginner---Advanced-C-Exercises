using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Count_of_workdays
{
    class Program
    {
        static void Main(string[] args)
        {
            Date calend = new Date();
            Console.WriteLine("This program calculates the number working days between today and a specific Date.");
            Console.Write("Enter End-Date in DD/MM/YYYY format: ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int days = calend.GetCountOfDays(date);
            Console.Write("There is {0} Working days between today and your entry.", days);
            Console.ReadKey();
        }
    }
    class Date
    {
        public DateTime now = DateTime.Now.Date;
        private DateTime[] holidays = new DateTime[16];
        private DayOfWeek[] weekend = new DayOfWeek[2];

        public int counter = 0;
        private void PopulateDate()
        {
            holidays[0] = DateTime.ParseExact("01/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[1] = DateTime.ParseExact("01/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[2] = DateTime.ParseExact("14/04/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[3] = DateTime.ParseExact("17/04/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[4] = DateTime.ParseExact("01/05/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[5] = DateTime.ParseExact("29/05/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[6] = DateTime.ParseExact("25/06/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[7] = DateTime.ParseExact("26/06/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[8] = DateTime.ParseExact("27/06/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[9] = DateTime.ParseExact("01/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[10] = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[11] = DateTime.ParseExact("01/10/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[12] = DateTime.ParseExact("02/10/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[13] = DateTime.ParseExact("30/11/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[14] = DateTime.ParseExact("25/12/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            holidays[15] = DateTime.ParseExact("26/12/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            weekend[0] = DayOfWeek.Saturday;
            weekend[1] = DayOfWeek.Sunday;
        } 
        public int GetCountOfDays(DateTime date)
        {
            if (now > date)
            {
                return counter;
            }
            else
            {
                PopulateDate();
                now = now.AddDays(1);
                if (IfWeekend(now) || IfHoliday(now))
                {
                    GetCountOfDays(date);
                }
                else
                {
                    counter++;
                    GetCountOfDays(date);
                }
                return counter;
            }
        }
        
        private bool IfWeekend(DateTime date)
        {
            DayOfWeek now = date.DayOfWeek;
            for (int i = 0; i < weekend.Length; i++)
            {
                if (now == weekend[i])
                {
                    return true;
                }
            }
            return false;
        }
        private bool IfHoliday(DateTime date)
        {
            for (int i = 0; i < holidays.Length; i++)
            {
                if (date == holidays[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
