using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_One
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sule = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            int var = sule[0];
            IDictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int value in sule)
            {
                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict[value] = 1;
                }
            }
            foreach (KeyValuePair<int, int> pair in dict)
            {
                Console.WriteLine(string.Format("{0} occurs {1} times.", pair.Key, pair.Value));
            }
            Console.ReadKey();
        }
    }
}
