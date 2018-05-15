using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Fraction\r\n(e.g 2/3): ");
            string text = Console.ReadLine();
            Fraction fraction = Fraction.Parse(text);
            Console.WriteLine(text + " = " + fraction.Value);
            string test = Fraction.CancelFraction("5/10");
            Console.ReadKey();
        }
    }

    class Fraction
    {
        private decimal fraction = 0.0m;
        public decimal Value
        {
            get { return fraction; }
        }
        public Fraction(decimal frac)
        {
            fraction = frac;
        }
        public static Fraction Parse(string text)
        {
            string[] arr = text.Trim().Split('/');
            decimal decOne = decimal.Parse(arr[0]);
            decimal decTwo = decimal.Parse(arr[1]);
            return new Fraction(decOne / decTwo);
            
        }
        public static string CancelFraction(string frac)
        {
            string[] arr = frac.Trim().Split('/');
            int[] tmp = { int.Parse(arr[0]), int.Parse(arr[1]) };
            int swt = 0;
            for (int i = 2; i < 200; i++)
            {
                if (tmp[0] % i == 0 && tmp[1] % i == 0)
                {
                    swt = i;
                    break;
                }
            }
            if (swt != 0)
            {
                return string.Format("{0} canceled to {1}/{2}", frac, tmp[0] / swt, tmp[1] / swt);
            }
            else
            {
                return string.Format("Could not cancel fraction.");
            }
        }
    }
}
