using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter First Number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter Third Number: ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("Enter Fourth Number: ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Enter Fifth Number: ");
            int e = int.Parse(Console.ReadLine());

            List<int> numberArray = new List<int>();
            numberArray.Add(a);
            numberArray.Add(b);
            numberArray.Add(c);
            numberArray.Add(d);
            numberArray.Add(e);

            int greatestNumber = 0;
            foreach (int number in numberArray)
            {
                if (greatestNumber < number)
                    greatestNumber = number;
            }

            Console.WriteLine("Greatest number = " + greatestNumber);
            Console.ReadKey();
        }
    }
}
