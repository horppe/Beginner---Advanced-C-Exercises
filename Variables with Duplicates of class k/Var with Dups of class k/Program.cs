using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var_with_Dups_of_class_k
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");                    //Insert values
            int k = int.Parse(Console.ReadLine());
            int[] loops = new int[k];


            Console.WriteLine("Recursive Algorithm:");  
            Variants(loops, n, 0);

            Console.WriteLine("Iterative Algorithm:");
            IterativeVersion(loops, n);

            Console.ReadKey();
        }

        static void Variants(int[] array, int n, int pos)
        {
            if (pos == array.Length)
            {
                PrintComb(array);           //Recursion bottom
                return;
            }
            
                for (int i = 1; i <= n; i++)    //Recursive Algoroithm to print variants
                {
                    array[pos] = i;
                    Variants(array, n, pos + 1);  //Call the Recursive methods
                }
            
        }

        static void IterativeVersion(int[] array, int n)
        {
            DefaultValue(array);
            int pos;
            while (true)
            {
                // current position equals array length
                pos = array.Length - 1;
                PrintComb(array);
                array[pos] = array[pos] + 1;        //Increment the last value
                while (array[pos] > n)
                {
                    array[pos] = 1;                         //Iterative algorithm to print variants
                    pos--;
                    if (pos < 0)
                    {
                        return;           //Condition to stop loops and return method
                    }
                    array[pos] = array[pos] + 1;   //Increment the left index value
                }
            }

        }

        static void DefaultValue(int[] array)
        {
            for (int i = 0; i < array.Length; i++)      //Change all index values to 1
            {
                array[i] = 1;
            }
        }

        static void PrintComb(int[] array)
        {
            Console.Write("(");
            for (int i = 0; i < array.Length; i++)     //Print current combination
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
        
    }
}
