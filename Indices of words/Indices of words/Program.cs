using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indices_of_words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Word: ");
            string word = Console.ReadLine();
            char[] alpha = {  'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int[] array = new int[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (word[i] == alpha[j])
                    {
                        array[i] = j;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                    Console.Write(alpha[array[i]] + " ");
            }

            Console.WriteLine();

            Console.Write("Indices are: ");            
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
