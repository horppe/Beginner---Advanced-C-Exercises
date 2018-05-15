using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicographical_order
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[9];
            int[] reversed = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            int n = array.Length;

            for (int i = 0; ((i < reversed.Length) && (n > 0)); i++)
            {
                n--;
                reversed[i] = n;
            }

            for (int i = 0; i < reversed.Length; i++)
            {
                Console.WriteLine(reversed[i]);
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
 