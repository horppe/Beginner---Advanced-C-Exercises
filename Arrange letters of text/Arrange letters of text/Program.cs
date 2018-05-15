using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrange_letters_of_text
{
    class Program
    {
        static int[] counts;
        static List<char> let = new List<char>();
        static List<string> words = new List<string>();
        static char[] format = { '\r', '\n', ' ', '.' };
        static int[] wordCount;

        static void Main(string[] args)
        {
            string text = "Write a program that reads a string from the " +
                        "console and prints in alphabetical order all letters" +
                        "\r\nfrom the input string and how many times each one of" +
                        "them occurs in the string\n";
            Console.WriteLine("Input 1 to operate on characters and 2 to operate on words: ");
            string intrface = Console.ReadLine();
            //Console.Write("Enter Text: ");
            //string text = Console.ReadLine();
            switch (intrface)
            {
                case "1": OperateOnChars(text); break;
                case "2": OperateOnWords(text); break;
                case "Quit": return;
                case "quit": return;
                case "Exit": return;
                case "exit": return;
                case "Close": return;
                case "close": return;
                default: Console.WriteLine("Incorrect command.");
                    Main(args);
                    break;
            }
            Console.ReadKey();
        }

        static void OperateOnWords(string text)
        {
            ExtractWords(text);
            SortWords();
            wordCount = new int[words.Count];
            CountWords(text);
            PrintWords(text);
            Console.ReadKey();
        }

        static void ExtractWords(string text)
        {
            char[] sep = { ' ', ',', '.', '\r', '\n' };
            string[] wordsArr = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordsArr.Length; i++)
            {
                if (WordNotInList(wordsArr[i]))
                {
                    words.Add(wordsArr[i]);
                }
            }
        }

        static bool WordNotInList(string word)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i] == word)
                {
                    return false;
                }
            }
            return true;
        }

        static void SortWords()
        {
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    string left = words[i].ToLower();
                    string right = words[j].ToLower();
                    if (left.CompareTo(right) == 1)
                    {
                        string temp = words[i];
                        words[i] = words[j];
                        words[j] = temp;
                    }
                }
            }
        }

        static void CountWords(string text)
        {
            string[] tempArr = text.Split(format, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < tempArr.Length; j++)
                {
                    if (words[i] == tempArr[j])
                    {
                        wordCount[i]++;
                    }
                }
            }
            
        }

        static void PrintWords(string text)
        {
            Console.WriteLine("This is a Text : \r\n{0}", text);
            Console.WriteLine("List of the words in the text above with a frequency list:");
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i].PadRight(15) + " == " + wordCount[i]);
            }
        }

        static void OperateOnChars(string text)
        {
            ExtractLetters(text);
            SortChars();
            counts = new int[let.Count];
            CountLetters(text);
            PrintChars(text);
        }

        static void ExtractLetters(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (CharIsInText(text[i]))
                {
                    if (IsNotInList(text[i]))
                    {
                        let.Add(text[i]);
                    }
                }
            }
        }

        static bool CharIsInText(char ch)
        {
            switch (ch)
            {
                case '.': return false;
                case '\r': return false;
                case '\n': return false;
                case ' ': return false;
                default: return true;
            }
        }

        static bool IsNotInList(char ch)
        {
            for (int i = 0; i < let.Count; i++)
            {
                if (let[i] == ch)
                {
                    return false;
                }
            }
            return true;
        }

        static void SortChars()
        {
            for (int i = 0; i < let.Count; i++)
            {
                for (int j = i + 1; j < let.Count; j++)
                {
                    if (let[i] > let[j])
                    {
                        char tmp = let[i];
                        let[i] = let[j];
                        let[j] = tmp;
                    }
                }
            }
        }

        static void CountLetters(string text)
        {
            for (int i = 0; i < let.Count; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (let[i] == text[j])
                    {
                        counts[i]++;
                    }
                }
            }
        }

        static void PrintChars(string text)
        {
            Console.WriteLine("This is a Text : \r\n{0}", text);
            Console.WriteLine("List of the characters in the text above with a count of each individual occurence:");
            for (int i = 0; i < let.Count; i++)
            {
                Console.WriteLine(let[i] + " == " + counts[i]);
            }
        }
    }
}
