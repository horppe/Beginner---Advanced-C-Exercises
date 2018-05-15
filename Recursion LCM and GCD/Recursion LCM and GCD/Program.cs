using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_LCM_and_GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter M: ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("The GCD of {0} and {1} is {2}.",n, m, GCD(n, m));
            Console.WriteLine("The LCM of {0} and {1} is {2}.", n, m, LCM(n, m));
            Console.ReadKey();
        }

        static void FactorDiv(int number, List<int> array, int pos)
        {
            if (pos > number)
            {
                return;
            }
            else
            {           //If the current variable pos divides number without any remainder then it is added as a Factor
                if (number % pos == 0)
                {
                    array.Add(pos);
                }
                FactorDiv(number, array, pos + 1);
                return;
            }
        }
        
        static int GCD(int n, int m)
        {
            List<int> arrN = new List<int>();
            FactorDiv(n, arrN, 1);
            List<int> arrM = new List<int>();
            FactorDiv(m, arrM, 1);
            int result = 0;
            for (int i = 0; i < arrN.Count; i++)
            {
                for (int j = 0; j < arrM.Count; j++)
                {
                    if (arrN[i] == arrM[j])     //Nested loop searches for the highest common number in both lists
                    {
                        result = arrN[i];
                    }
                }
            }
            return result;
        }
        static void FactorMulti(int number, List<int> array, int pos)
        {
            if (pos > 10)
            {
                return;
            }
            else
            {               //The result of the multiplication of pos with number are added as Factors to the list.
                array.Add(number * pos);
                FactorMulti(number, array, pos + 1);
            }
        }
        static int LCM(int n, int m)
        {
            List<int> arrN = new List<int>();
            FactorMulti(n, arrN, 1);
            List<int> arrM = new List<int>();
            FactorMulti(m, arrM, 1);
            int result = 0;
            for (int i = arrN.Count - 1; i >= 0; i--)
            {
                for (int j = arrM.Count - 1; j >= 0; j--)
                {
                    if (arrN[i] == arrM[j])     //Nested loop searches for the lowest common number in both lists.
                    {
                        result = arrN[i];
                    }
                }
            }
            return result;
        }
    }
}
