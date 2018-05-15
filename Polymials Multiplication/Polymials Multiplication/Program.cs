using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymials_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(Ax^2 + x + B) * (x + C)");
            Console.Write("Enter A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter B: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter C: ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("Enter X: ");
            int x = int.Parse(Console.ReadLine());
            CreateXPower(x);
            int[][] array = CreateArray(a, b, c, x);
            int sum = CalculatePolymial(array);
            Console.WriteLine("(Ax^2 + x - B) * (x - C) = {0}", sum);
            Console.ReadKey();
        }
        static int[] CreateXPower(int x)
        {
            int[] xPower = new int[10];
            xPower[0] = 1;
            int count = 1;
            for (int i = 1; i < xPower.Length; i++)
            {
                xPower[i] = count *= x;
            }
            
            return xPower;
        }
        static int[][] CreateArray(int a, int b, int c, int x)
        {
            int[] polOne = { b, 1, a };
            int[] polTwo = { c, 1 };
            int[] powerArr = CreateXPower(x);
            int[][] myArray = new int[2][];
            myArray[0] = new int[polOne.Length];
            myArray[1] = new int[polTwo.Length];
            for (int i = 0; i < myArray[0].Length; i++)
            {
                myArray[0][i] = polOne[i] * powerArr[i];
            }
            for (int i = 0; i < myArray[1].Length; i++)
            {
                myArray[1][i] = polTwo[i] * powerArr[i];
            }
            return myArray;
        }
        static int CalculatePolymial(int[][] myArray)
        {
            int sum = 0;
            List<int> array = new List<int>();
            for (int i = myArray[1].Length - 1; i >= 0 ; i--)
            {
                for (int j = myArray[0].Length - 1; j >= 0 ; j--)
                {
                    array.Add(myArray[1][i] * myArray[0][j]);
                }
            }
            for (int i = 0; i < array.Count; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
