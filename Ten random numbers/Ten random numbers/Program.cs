using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_random_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumbers rnd = new RandomNumbers();
            Console.Write("Enter Count of Numbers: ");
            int n = int.Parse(Console.ReadLine());
            rnd.GenNumber(n);
            Console.ReadKey();
        }
    }

    class RandomNumbers
    {
        public Random rnd = new Random();
        
        public void GenNumber(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int num = rnd.Next(100, 200) + 1;
                Console.Write(" {0}", num);
            }
        }
    }
}
