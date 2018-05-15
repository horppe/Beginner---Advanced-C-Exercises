using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_elements_out_of_N_with_S_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 1, 2, 4, 9, 6 };
            Console.Write("Input K: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Input S: ");
            int s = int.Parse(Console.ReadLine());
            int tmp = 0, count = k;
            List<int> index = new List<int>(k);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if ((tmp + array[j]) < (s + 1)  && count != 0)
                    {
                        tmp += array[j];
                        count--;
                        index.Add(j);
                    }
                    else
                    {
                        continue;
                    }
                }
                if ((tmp < s) || (tmp > s))
                {
                    count = k;
                    for (int a = index.Count - 1; a >= 0; a--)
                    {
                        index.Remove(index[a]);
                    }
                }
                if (tmp == s)
                {
                    break;
                }
            }
        }
    }
}
