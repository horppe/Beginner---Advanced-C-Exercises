using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How_many_times_each_element_occurs
{
    class Program
    {
        static List<int> array = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
        static void Main(string[] args)
        {   //This would be if i wanted to use random numbers from 1 to 1000 (array(List) would need to have only an empty instance)
            //Random rand = new Random();
            //for (int i = 1; i <= 1000; i++)
            //{
            //    array.Add(rand.Next(i, 1000));
            //}
            List<int> numbers = GetNumbers();
            List<string> list = new List<string>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int count = CountOccurence(numbers[i]);
                string format = string.Format("{0} is {1} times",numbers[i], count);
                list.Add(format);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadKey();
        }

        static List<int> GetNumbers()
        {   //This method extracts the only one copy of each element in the list and returns it as a List
            List<int> tempList = new List<int>();
            for (int i = 0; i < array.Count; i++)
            {   //If this element is already in the list i've prepared, then no need to add it to it again
                if (IsInList(array[i], tempList))
                {
                    tempList.Add(array[i]);
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

        static int CountOccurence(int n)
        {
            int counter = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (n == array[i])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
