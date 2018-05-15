using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_Test_project
{
    class Program
    {
        static List<int> array = new List<int>()
            {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2};
        static List<int> result = new List<int>();
        static void Main(string[] args)
        {   //This program removes all even numbers from a given sequence
            List<int> temp = new List<int>(array);
            for (int i = 0; i < array.Count; i++)
            {
                if (IsEven(array[i]))
                {//IsEven method checks if the current element is even
                    result.Add(array[i]);
                }
            }
            Console.ReadKey();
        }

        static bool IsEven(int number)
        {
            int counter = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (number == array[i])
                {   //If number is equal to a member of a copied list of same reference, increase counter.
                    counter++;
                }
            }
            if (counter % 2 == 0)
            {   //If counter is an even number, return true
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
