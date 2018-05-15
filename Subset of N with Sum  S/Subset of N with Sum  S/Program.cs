using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subset_of_N_with_Sum__S
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
            List<int> arrayList = new List<int>();
            Console.Write("Enter S: ");
            int s = int.Parse(Console.ReadLine());
            List<int> index = new List<int>();
            int counter = 0;
            int swt = 0;
            int tmp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (tmp + array[j] <= s)
                    {
                        tmp += j;
                        index.Add(j);
                    }
                    else
                    {
                        continue;
                    }
                    if (tmp == s)
                    {
                        swt = 1;
                        break;
                    }
                }
                if ((tmp < s) || (tmp > s))
                {
                    tmp = 0;
                    for (int a = index.Count - 1; a >= 0; a--)
                    {
                        index.Remove(index[a]);
                    }
                }
                if (swt == 1)
                {
                    break;
                }
                
            }

            for (int i = 0; i < index.Count; i++)
            {
                Console.Write(index[i] + " ");
            }
            Console.Write("The total is {0}.", tmp);


            Console.ReadKey();
        }
    }
}
