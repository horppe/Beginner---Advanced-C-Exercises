using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations_of_N_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Recursive Permutation:");
            Combination(array, 0);
            Console.WriteLine("Iterative Permutation:");
            ItPermutation(array);
            Console.ReadKey();
        }

        static void ItPermutation(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1;
            }
            while (true)
            {
                int pos = array.Length - 1;
                if (Permutation(array))
                {
                    PrintArray(array);
                }
                array[pos]++;
                while (array[pos] > array.Length)
                {
                    array[pos] = 1;
                    pos--;
                    if (pos < 0)
                    {
                        return;
                    }
                    else
                    {
                        array[pos]++;
                    }
                }
            }
        }
        
        static void Combination(int[] array, int pos)
        {
            if (pos == array.Length)
            {
                if (Permutation(array))
                {
                    PrintArray(array);
                }
            }
            else
            {
                for (int i = 1; i <= array.Length; i++)
                {
                    array[pos] = i;
                    Combination(array, pos + 1);
                }
            }
        }

        static bool Permutation(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] != array[j])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void PrintArray(int[] array)
        {
            Console.Write("(");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
    }
}
