using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_operations_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to Print Reverse Order of Integer");
            Console.WriteLine("Press 2 for average of Sequence of numbers");
            Console.WriteLine("Press 3 to Solve Equation");
            Console.Write("Enter option: ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: ReverseNo(); break;
                case 2: AverageOfSequence(); break;
                case 3: Equation(); break;
                default: Console.WriteLine("Invalid Option.");
                    break;
            }

        }
        static void ReverseNo()
        {
            Console.Write("Enter Number: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("The reverse order of the No. is: ");
            PrintArray(ReverseOrder(n));
            Console.ReadKey();
        }
        static int[] ReverseOrder(int number)
        {
            int count = 0, i = 0;
            int[] array = new int[number.ToString().Length];
            while (number > 0)
            {
                count = number % 10;
                number /= 10;
                array[i++] = count;
            }
            return array;
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}", array[i]);
            }
        }
        static void AverageOfSequence()
        {
            Console.Write("Enter Numbers seperated by space: ");
            string n = Console.ReadLine();
            string[] array = n.Split(null);
            int[] myArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                myArray[i] = int.Parse(array[i]);
            }
            Console.Write("Average of Array [");
            PrintArray(myArray);
            Console.Write("]");
            Console.Write(" is {0}.", AverageNumbers(myArray));
            Console.ReadKey();
        }
        static int AverageNumbers(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum / 2;
        }
        static void Equation()
        {
            Console.WriteLine("For \"a * x + b = 0\" Enter A & B");
            Console.Write("Enter A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter B: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("X = {0}", SolveEquation(a, b));
        }
        static int SolveEquation(int a, int b)
        {
            int x = 0;
            for (int i = -1000; i < 1000; i++)
            {
                if ((a * i) + b == 0)
                {
                    x = i;
                }
            }
            return x;
        }
    }
}
