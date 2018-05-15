using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant
{
    class Program
    {
        static List<int> seq = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        static void Main(string[] args)
        {   //Find the element whose occurence equals the Length of the list of sequence divided by 2 plus 1
            int majorant = 0, criteria = (seq.Count / 2) + 1;
            List<int> list = GetNumbers();  //First get each individual numbers, and the compare with those.
            for (int i = 0; i < list.Count; i++)
            {
                int temp = CountNumbers(list[i]);
                if (temp >= criteria)
                {   //If the count of each individual element is up to the criteria.
                    majorant = list[i];
                    break;
                }
            }

            Console.WriteLine("The majorant is " + majorant);
            Console.ReadKey();
        }

        static int CountNumbers(int n)
        {   //Count the number of times n occurs in the List seq
            int counter = 0;
            for (int i = 0; i < seq.Count; i++)
            {
                if (n == seq[i])
                {
                    counter++;
                }
            }
            return counter;
        }

        static List<int> GetNumbers()
        {   //This method extracts the only one copy of each element in the list and returns it as a List
            List<int> tempList = new List<int>();
            for (int i = 0; i < seq.Count; i++)
            {   //If this element is already in the list i've prepared, then no need to add it to it again
                if (IsInList(seq[i], tempList))
                {
                    tempList.Add(seq[i]);
                }
            }
            return tempList;
        }

        static bool IsInList(int n, List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {   //If the element matches one already in the list, return 'false',
                if (n == list[i])
                {
                    return false;
                }
            }
            return true;    //Otherwise return 'true'
        }
    }
}
