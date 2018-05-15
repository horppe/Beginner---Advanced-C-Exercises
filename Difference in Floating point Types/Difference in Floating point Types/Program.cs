using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Difference_in_Floating_point_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            float fl = 0.000001f;
            float flSum = 0.0f;
            System.Diagnostics.Stopwatch myStopWatch = new System.Diagnostics.Stopwatch();
            myStopWatch.Start();
            for (int i = 0; i < 50000000; i++)
            {
                flSum += fl;                                    //Sum the values
            }
            Console.WriteLine(flSum + " is the Float Sum");
            myStopWatch.Stop();

            Console.WriteLine("{0}", myStopWatch.Elapsed.Seconds.ToString());

            double dl = 0.000001d;
            double dlSum = 0.0d;
            for (int i = 0; i < 50000000; i++)          
            {
                dlSum += dl;
            }
            Console.WriteLine("{0} is the Double Sum", dlSum);

            decimal dc = 0.000001m;
            decimal dcSum = 0.0m;
            for (int i = 0; i < 50000000; i++)
            {
                dcSum += dc;
            }
            Console.WriteLine("{0} is the Decimal Sum", dcSum);     //Print the results

            Console.ReadKey();
        }
    }
}
