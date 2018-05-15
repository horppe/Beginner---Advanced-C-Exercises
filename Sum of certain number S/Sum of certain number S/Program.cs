using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_certain_number_S
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter S: ");
            int s = int.Parse(Console.ReadLine());
            int[] array = { 4, 3, 1, 4, 2, 5, 8 };
            List<int> otherArray = new List<int>();
            int counter = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                counter = 0;
                for (int j = i; j < array.Length - 1; j++)
                {
                    counter += array[j];
                    if (counter == s)
                    {
                        for (int a = otherArray.Count - 1; a >= 0; a--)
                        {
                            otherArray.Remove(otherArray[a]);
                        }
                        for (int k = i; k <= j; k++)
                        {
                            otherArray.Add(array[k]);
                        }
                        break;
                    }
                }
            }

            for (int i = 0; i < otherArray.Count; i++)
            {
                Console.Write(otherArray[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
