using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = { 1, 3, 5, 7, 9 , 11, 13, 15, 17, 19};
            int[] arrayTwo = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20};  //These two arrays need to be sorted already for merge to be done.
            int n = arrayOne.Length + arrayTwo.Length;
            int[] myArray = new int[n];
            int i = 0, j = 0, k = 0;
            while (k < myArray.Length)
            {
                if (arrayOne[i] < arrayTwo[j]) 
                {
                    myArray[k++] = arrayOne[i++];
                }
                else if (arrayTwo[j] < arrayOne[i])
                     {
                         myArray[k++] = arrayTwo[j++];
                     }
                if (i == arrayOne.Length)
                {
                    myArray[k] = arrayTwo[j];       //After iterating through both arrays, the last element of the other...
                    break;                          //sub-array cannot be accessed. This condition includes it in the array.
                }
                else if (j == arrayTwo.Length)
                {
                    myArray[k] = arrayOne[i];
                    break;
                }
            }
            for (int a = 0; a < myArray.Length; a++)
            {
                Console.Write(myArray[a] + " ");
            }

            Console.ReadKey();
        }
    }
}
