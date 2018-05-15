using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Most_frequently_occuring_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            List<int> secondArray = new List<int>();
            List<int> thirdArray = new List<int>();
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i; j < array.Length - 1; j++)
                {
                    if (array[i] == array[j])
                    {
                        secondArray.Add(array[j]);
                    }
                }

                if (secondArray.Count > thirdArray.Count)
                {
                    for (int j = 0; j < secondArray.Count; j++)
                    {
                        thirdArray.Add(secondArray[j]);
                    }
                }

                for (int j = secondArray.Count - 1; j >= 0; j--)
                {
                    secondArray.Remove(secondArray[j]);
                }
            }

            for (int i = 0; i < thirdArray.Count; i++)
            {
                Console.Write(thirdArray[i] + " ");
            }

            Console.Write("__({0}) Numbers.", thirdArray.Count);

            Console.ReadKey();
        }
    }
}
