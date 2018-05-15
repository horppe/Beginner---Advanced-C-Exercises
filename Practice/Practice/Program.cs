using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static int[] array = { 3, 2, 3, 4, 5 };
        static void Main(string[] args)
        {
            foreach  (int i in array)
            {
                ChangeValue(i);
            }
        }
        static void ChangeValue(int n)
        {
            array[0] = 6;
        }
    }
}
