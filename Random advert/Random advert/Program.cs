using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_advert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program prints a specified number of Advert messages.");
            Console.Write("How many messages do you want: ");
            int n = int.Parse(Console.ReadLine());
            RandomMessage.PrintRandom(n);
            Console.ReadKey();
        }
    }
    class RandomMessage
    {
        private static string[] phrase = { "The product is excellent.",
            "This is a great product.",
            "I use this product constantly.",
            "This is the best product from this category." };
        private static string[] stories = { "Now I feel better.", "I managed to change.",
            "It made some miracle.",
            "I can’t believe it, but now I am feeling great.",
            "You should try it, too. I am very satisfied." };
        private static string[] firstName = { "Dayan", "Stella", "Hellen", "Kate" };
        private static string[] lastName = { "Johnson", "Peterson", "Charls" };
        private static string[] cities = { "London", "Paris", "Berlin", "New York", "Madrid" };
        private static Random rand = new Random();

        private static int GetRandomIndex(string[] array)
        {
            return rand.Next(array.Length);
        }
        public static void PrintRandom(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0} {1} -- {2} {3}, {4}.", phrase[GetRandomIndex(phrase)], stories[GetRandomIndex(stories)],
               firstName[GetRandomIndex(firstName)], lastName[GetRandomIndex(lastName)], cities[GetRandomIndex(cities)]);
                Console.WriteLine();
            }
        }
    }
}
