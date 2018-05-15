using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varitations_of_K_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            int[] kArray = new int[k];
            for (int i = 0; i < kArray.Length; i++)
            {
                kArray[i] = 1;
            }
            
            

            Console.ReadKey();
        }
        static void IncrementIndex(int index , int[] array)
        {
            if (true)
            {

            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    if (true)
                    {
                        PrintArray(array);
                    }
                    else
                    {

                    }
                    

                }
                int size = 1;
                IncrementIndex( , array);
            }
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
