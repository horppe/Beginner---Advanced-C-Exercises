using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample3
{
    class Program
    {
        static void Main(string[] args)
        {

            int mask = 1;
            mask = mask << 3;
            int addMask = 30 & mask;
            if (addMask != 0)
            {
                Console.WriteLine("The bit in Position {0} is 1.", + mask);
            }
            else
            {
                Console.WriteLine("The bit in Position {0} is 0." + mask);
            }
            Console.ReadKey();
        }
    }
}
