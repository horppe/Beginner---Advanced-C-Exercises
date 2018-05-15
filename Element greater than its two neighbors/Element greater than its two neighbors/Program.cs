using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element_greater_than_its_two_neighbors
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 4, 5, 6, 7, 8, 2, 4, 5, 1, 9, 0, 8, 7, 5, 3, 1, 2, 4, 6, 8, 9 };
            List<int> myArray = FindElement(array);
            PrintArray(array);
            Console.WriteLine();
            PrintList(myArray);
            
            Console.ReadKey();
        }

        static List<int> FindElement(int[] arrayi)
        {
            List<int> resultArray = new List<int>();
            for (int i = 1; i < arrayi.Length - 1; i++)
            {
                if ((arrayi[i] > arrayi[i - 1]) && (arrayi[i] > arrayi[i + 1]))
                {
                    resultArray.Add(arrayi[i]);
                }
            }
            return resultArray;
        }
        static void PrintList(List<int> array)
        {
            Console.Write("[ ");
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write( array[i] + " ");
            }
            Console.Write("] ");
            Console.WriteLine("The number of elements is: {0}", array.Count);
        }
        static void PrintArray(int[] array)
        {
            Console.Write("[ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.Write("]");
        }

    }
}
