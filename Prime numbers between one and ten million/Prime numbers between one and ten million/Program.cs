using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_numbers_between_one_and_ten_million
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 10000000; i++)
            {
                int swt = 0;
                for (int j = 2; j < i; j++)
                {
                    if (i % j != 0)
                    {
                        swt = 1;
                    }
                    else if (i % j == 0)
                    {
                        swt = 0;
                        break;
                    }
                }
                if (swt == 1)
                {
                    Console.WriteLine(i);
                }
            }
            

            Console.ReadKey();
        }
    }
}
