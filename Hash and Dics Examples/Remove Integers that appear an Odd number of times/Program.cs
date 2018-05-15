using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Integers_that_appear_an_Odd_number_of_times
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6 };
            Dictionary<int, int> list = GetFrequency(array);
            List<int> result = RemoveOddEntries(array, list);
            Console.ReadKey();
        }

        static List<int> RemoveOddEntries(int[] array, Dictionary<int, int> list)
        {
            List<int> result = new List<int>();
            List<int> deletion = new List<int>();
            foreach (var pair in list)
            {
                if (pair.Value % 2 != 0)
                {
                    deletion.Add(pair.Key);
                }
            }

            foreach (var i in array)
            {
                if (IsIn(i, deletion))
                {
                    continue;
                }
                else
                {
                    result.Add(i);
                }
            }
            return result;
        }

        static bool IsIn(int key, List<int> deletionList)
        {
            foreach (var k in deletionList)
            {
                if (k == key)
                {
                    return true;
                }
            }
            return false;
        }

        static Dictionary<int, int> GetFrequency(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int value in array)
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
            return dict;
        }
    }
}
