using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Consecutive_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int counter = 0;
            int holder = 0;
            int element = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0}:", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int a = 0; a < n - (k - 1); a++)
            {
                for (int b = a; b <= a + (k - 1); b++)
                     
                {
                    counter += array[b];
                }
                if (counter > holder)
                {
                    holder = counter;
                    counter = 0;
                    element = a;
                }
                else
                {
                    counter = 0;
                    continue;
                }
            }
                
            
            for (int i = element; i < (element + k); i++)
            {
                Console.Write(array[i] + " ");
            }
            for (int i = element; i < (element + k); i++)
            {
                counter += array[i];
            }
            Console.WriteLine("The total Max is {0}", counter);


            Console.ReadKey();
        }
    }
}
