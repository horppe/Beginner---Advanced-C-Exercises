using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subset_of_a_given_n_set
{
    class Program
    {
        static string[] words = { "Test", "Rock", "Fun" };
        static int length = words.Length;
        static void Main(string[] args)
        {
            Console.WriteLine("Recursive algorithm:");
            GenerateSet();
            Console.WriteLine();
            Console.WriteLine("Iterative algorithm:");
            Console.WriteLine("()");
            for (int i = 0; i < length; i++)
            {
                string[] array = new string[i + 1];
                ItGenSubset(array);
            }
            Console.ReadKey();
        }
        static void ItGenSubset(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = words[0];
            }
            int pos = 0;
            while (true)
            {
                int index = array.Length - 1;
                array[index] = words[pos++];
                if (ValidateArray(array))
                {
                    PrintArray(array);
                }
                while (pos == length)
                {
                    array[index] = words[0];
                    index--;
                    int nextPos = GenNextPos(array, index);
                    if (nextPos == -1)
                    {
                        return;
                    }
                    else
                    {
                        array[index] = words[nextPos];
                    }
                    pos = 0;
                }
            }
        }

        static int GenNextPos(string[] array, int pos)
        {
            if (pos >= 0)
            {
                int swt = 0;
                for (int i = 0; i < length; i++)
                {
                    if (words[i] == array[pos])
                    {
                        if (i != length - 1)
                        {
                            swt = i + 1;
                            break;
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
            else
            {
                return -1;
            }
            
        }

        static void GenerateSet()
        {
            Console.WriteLine("()");
            for (int i = 0; i < length; i++)
            {
                string[] array = new string[i + 1];
                GenAllSubset(array, i + 1, 0);
            }
        }
        static void GenAllSubset(string[] array, int index, int pos)
        {
            if (pos == index)
            {
                if (ValidateArray(array))
                {
                    PrintArray(array);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    array[pos] = words[i];
                    GenAllSubset(array, index, pos + 1);
                }
            }
        }

        static bool ValidateArray(string[] array)
        {
            if (array.Length < 2)
            {
                return true;
            }
            else
            {
                List<int> index = new List<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (array[i] == words[j])
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
        }
        
        static bool ValidateIndex(List<int> array)
        {
            int swt = 0;
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i+1] > array[i])
                {
                    swt = 1;
                }
                else
                {
                    swt = 2;
                    break;
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

        static void InitializeArr(string[] array, string[] wkArray, int pos )
        {
            for (int i = 0; i <= pos; i++)
            {
                wkArray[i] = array[i];
            }
        }
        static void PrintArray(string[] array)
        {
            Console.Write("(");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
    }
}
