using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_two_long__integer_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Long No. 1: ");
            long no1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Long No. 2: ");
            long no2 = int.Parse(Console.ReadLine());
            long[] arrayOne = ConvertToArray(no1);
            long[] arrayTwo = ConvertToArray(no2);
            Console.Write("The 1st Array: ");
            PrintArray(arrayOne);
            Console.WriteLine();
            Console.Write("The 2nd Array: ");
            PrintArray(arrayTwo);
            long[] sumArray = SumArray(arrayOne, arrayTwo);
            Console.WriteLine();
            Console.Write("The Sum Array: ");
            PrintArray(sumArray);
            Console.ReadKey();

        }
        static long[] ConvertToArray(long number)
        {
            long size = number.ToString().Length;
            long[] array = new long[size];
            long count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count = number % 10;
                number /= 10;
                array[i] = count;
            }
            return array;
        }
        static void PrintArray(long[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.Write("]");
        }
        static long[] SumArray(long[] arrayOne, long[] arrayTwo)
        {
            long length = (arrayOne.Length + arrayTwo.Length) / 2;
            long[] sum = new long[length];
            for (int i = 0; i < length; i++)
            {
                sum[i] = arrayOne[i] + arrayTwo[i];
            }
            return sum;
        }
    }
}
