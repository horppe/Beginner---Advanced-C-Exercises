using System;
using System.Collections.Generic;


namespace Fib_Test
{
    class Program
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());            
            int[] result = Fib(n);
            foreach (int number in result)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
        static int[] Fib(int n)
        {
    
            List<int> fibArray = new List<int>();
            fibArray.Add(0);
            fibArray.Add(1);

            int count = 2;
            while(count < n)
            {
                // "count" is the current length of the List and return factor dependent on "n"
                int number = fibArray[count - 2] + fibArray[count -1];
                fibArray.Add(number);
                count++;
            }

            return fibArray.ToArray();
        }
    }
}
