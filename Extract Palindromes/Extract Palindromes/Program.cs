using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Extract_Palindromes
{
    class Program
    {
        static List<string> list = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                using (StreamReader file = new StreamReader("Sample.txt"))
                {
                    while (!file.EndOfStream)
                    {
                        char[] formats = { '.', ' ', ',' };
                        string[] line = file.ReadLine().Split(formats);
                        ExtractPlaindromes(line);
                    }
                }
                PrintWords();
            }
            catch (IOException)
            {
                Console.WriteLine("There is something wrong the file being read.");
            }
            finally
            {
                Console.ReadKey();
            }

            
        }

        static void ExtractPlaindromes(string[] line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (IsPalindrome(line[i]))
                {
                    list.Add(line[i]);
                }
            }
        }

        static bool IsPalindrome(string word)
        {
            if (word == "")
            {
                return false;
            }
            else
            {
                for (int j = 0, k = word.Length - 1; j < word.Length / 2; j++, k--)
                {
                    if (word[j] != word[k])
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                return true;
            }
        }

        static void PrintWords()
        {
            Console.WriteLine("The following Palindromic words were found in the Text file:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Trim());
            }
        }
    }
}
