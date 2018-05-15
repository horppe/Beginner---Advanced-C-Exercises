using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_to_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number: ");
            int n = int.Parse(Console.ReadLine());
            List<int> array = new List<int>();
            int temp = 0;
            while (n > 0)
            {
                temp = n % 2;
                n /= 2;
                if ((temp == 1) || (temp == 0))
                {
                    array.Add(temp);
                }
            }
            for (int i = array.Count - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
