using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Occurence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 4, 5, 6, 7, 8, 2, 4, 5, 1, 9, 0, 8, 7, 5, 3, 1, 2, 4, 6, 8, 9 };
            Console.WriteLine("Index {0} is the position of {1}", FindElement(array), array[FindElement(array)]);

            Console.ReadKey();
        }
        static int FindElement(int[] arrayi)
        {
            int tmp = 0;
            for (int i = 1; i < arrayi.Length - 1; i++)
            {
                if ((arrayi[i] > arrayi[i - 1]) && (arrayi[i] > arrayi[i + 1]))
                {
                    tmp = i;
                    break;
                }
            }
            return tmp;
        }
    }
}
