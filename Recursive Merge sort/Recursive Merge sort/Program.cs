using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Merge_sort
{
    class Program
    {
        static int[] array = { 2, 5, 8, 3, 4, 6, 1, 7 };
        static int[] tempArr = new int[array.Length];
        static int last = array.Length - 1;
        static void Main(string[] args)
        {
            Console.WriteLine("List before sorting:");
            for (int i = 0; i <= last; i++)
            {
                Console.Write(" {0} ", array[i]);
            }
            DivideList(0, last);
            Console.WriteLine();
            Console.WriteLine("List after Merge sorting:");
            for (int i = 0; i <= last; i++)
            {
                Console.Write(" {0} ", array[i]);
            }
            Console.ReadKey();
        }
        static void DivideList(int strt, int end)
        {
            if (strt < end)
            {
                int mid = (strt + end) / 2;
                DivideList(strt, mid);
                DivideList(mid + 1, end);
                SortList(strt, mid, end);
            }
            else
            {
                return;
            }
        }
        static void SortList(int strt, int mid, int end)
        {
            int arrOne = strt, arrTwo = mid + 1, len = strt;
            while (len <= end)
            {
                if (array[arrOne] < array[arrTwo] && arrOne <= mid)
                {
                    tempArr[len++] = array[arrOne++];
                }
                else
                {
                    tempArr[len++] = array[arrTwo++];
                }
                
            }

            for (int i = strt; i <= end; i++)
            {
                array[i] = tempArr[i];
            }
        }
    }
}
