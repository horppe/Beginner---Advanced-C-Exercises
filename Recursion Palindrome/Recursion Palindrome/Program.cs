using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a Palindrome word: ");
            string word = Console.ReadLine();
            int len = word.Length;
            bool isValid = true;
            bool check = CheckIfPalindrome(isValid, word, len - 1, 0);
            if (check)
            {
                Console.WriteLine("The word {0} is Palindrome", word);
            }
            else
            {
                Console.WriteLine("The word {0} is not Palindrome", word);
            }
            Console.ReadKey();
        }
        static bool CheckIfPalindrome(bool isValid, string word, int len, int pos)
        {
            int mid = word.Length / 2;
            if (pos == mid)
            {
                return isValid;
            }
            else
            {
                if (word[pos] != word[len])
                {
                    isValid = false;
                    return isValid;
                }
                return isValid && CheckIfPalindrome(isValid, word, len - 1, pos + 1);
            }
            
        }
    }
}
