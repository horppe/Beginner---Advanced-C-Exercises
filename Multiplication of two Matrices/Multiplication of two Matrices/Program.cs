using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_of_two_Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrixXMatrix = new int[36, 36];

            for (int i = 0, num = 1; i < matrixXMatrix.GetLength(0); num++, i++)
            {
                matrixXMatrix[0, i] = num;
            }

            for (int i = 0, num = matrixXMatrix.GetLength(1); num >= 1; num--, i++)
            {
                matrixXMatrix[1, i] = num;
            }

            Console.Write("Enter row: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter Column: ");
            int col = int.Parse(Console.ReadLine());

            int counter = 0;
            int place = 0;
            Console.WriteLine("First Matrix: ");
            for (int i = place; place < matrixXMatrix.GetLength(0); i++)
            {
                i = place;
                for (int j = i; j < (i + col); j++) 
                {
                    Console.Write(matrixXMatrix[0, j] + " ");
                    counter = j;
                }
                place = counter;
                place++;
                Console.WriteLine();
            }
            counter = 0;
            place = 0;
            Console.WriteLine();
            Console.WriteLine("Second matrix: ");
            for (int i = place; place < matrixXMatrix.GetLength(1); i++)
            {
                i = place;
                for (int j = i; j < (i + col); j++)
                {
                    Console.Write(matrixXMatrix[1, j] + " ");
                    counter = j;
                }
                place = counter;
                place++;
                Console.WriteLine();
            }

            int[] resultMatrix = new int[36];

            for (int i = 0; i < 36; i++) //The two matrix are now multiplied
            {
                    resultMatrix[i] = matrixXMatrix[0, i] * matrixXMatrix[1, i];
            }

            counter = 0;
            place = 0;
            Console.WriteLine();
            Console.WriteLine("And this is the Result Matrix: ");
            for (int i = place; place < resultMatrix.Length; i++)
            {
                i = place;
                for (int j = i; j < (i + col); j++)  //Print the result of the multiplication as a matrix in a new array
                {
                    Console.Write(resultMatrix[j] + " ");
                    counter = j;
                }
                place = counter;
                place++;
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}
