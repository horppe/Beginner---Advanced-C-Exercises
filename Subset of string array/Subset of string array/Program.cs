using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subset_of_string_array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "John", "Sarah", "Sam" };
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            string[] myArray = new string[k];
            Console.WriteLine("Recursive algorithm:");
            GetStringComb(array, myArray, 0);
            Console.WriteLine("Iterative algorithm:");
            ItGetStringComb(array, myArray);
            Console.ReadKey();
        }

        static void ItGetStringComb(string[] array, string[] myArray)
        {
            Initialize(array, myArray);
            int pos2 = 0;
            int n = array.Length;
            while (true)
            {
                int pos = myArray.Length - 1;
                myArray[pos] = array[pos2++];
                if (ValidateArray(array, myArray))          //The ValidateArray method ensures that the proper arrays are printed on the screen
                {
                    PrintArray(myArray);
                }
                while (pos2 == n)
                {
                    myArray[pos] = array[0]; 
                    pos--;
                    int nextPos = GenNextPos(pos, array, myArray);
                    if (nextPos == -1)
                    {
                        return;
                    }
                    myArray[pos] = array[nextPos];
                    pos2 = 0;
                }
            }
        }
        static int GenNextPos(int pos, string[] array, string[] myArray)
        {
            int swt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == myArray[pos])
                {
                    if (i != array.Length - 1)
                    {
                        swt = i + 1;
                    }
                }
            }
            if (swt != 0)
            {
                return swt;
            }
            else
            {
                return -1;
            }
        }
        static void GetStringComb(string[] array, string[] myArray, int pos)
        {
            if (pos == myArray.Length)
            {
                if (ValidateArray(array, myArray))
                {
                    PrintArray(myArray);
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    myArray[pos] = array[i];
                    GetStringComb(array, myArray, pos + 1);
                }
            }
        }

        static void PrintArray(string[] array)
        {
            if (array[0] != null)            //Ensures that an empty array will not be displayed on the console.
            {
                Console.Write("(");
                for (int i = 0; i < array.Length; i++)     //Print current combination
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
            else
            {
                return;                     //Returns the method if the array is empty so an empty array
            }                               //is not printed on the console.
        }

        static bool ValidateArray(string[] array, string[] myArray)
        {
            List<int> index = new List<int>();
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (myArray[i] == array[j])
                    {
                        index.Add(j);
                    }
                }
            }
            if (ValidateIndex(index))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ValidateIndex(List<int> index)
        {
            int swt = 0;
            for (int i = 0; i < index.Count - 1; i++)           //This method ensures that the next index is higher than the previous
            {
                if (index[i + 1] > index[i])
                {
                    swt = 1;
                }
                else
                {
                    swt = 2;
                }
            }
            if (swt == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Initialize(string[] array, string[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = array[0];
            }
        }
    }
}
