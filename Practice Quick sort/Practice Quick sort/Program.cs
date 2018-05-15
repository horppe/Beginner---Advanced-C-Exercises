using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Quick_sort
{
    class Program
    {
        static int[] array = { 2, 4, 6, 8, 1, 3, 5, 7, 9 };
        static void Main(string[] args)
        {
            QuickSort();
            Console.ReadKey();
        }
        static void QuickSort()
        {
            int piv = 2;
            Partition(piv);
        }
        static void Partition(int piv)
        {
            int strt = 0;
            int end = array.Length;
            while (true)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[piv] < array[i])
                    {

                    }
                }
            }
        }
    }
}
