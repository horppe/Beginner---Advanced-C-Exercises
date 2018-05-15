using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Count_number_of_words_in_a_file
{
    class Program
    {
        static List<string> words = new List<string>();
        static List<int> counts = new List<int>();
        static string file;
        static void Main(string[] args)
        {
            try
            {
                StreamReader reader = new StreamReader("words.txt");
                using (reader)
                {
                    while (!reader.EndOfStream)
                    {
                        words.Add(reader.ReadLine());
                    }
                }
                file = File.ReadAllText("text.txt");
                
                for (int i = 0; i < words.Count; i++)
                {
                    CountWords(words[i]);
                }
                SortCounts();
                StreamWriter writer = new StreamWriter("result.txt");
                using (writer)
                {
                    for (int i = 0; i < words.Count; i++)
                    {
                        writer.WriteLine("\"{0}\" occured {1} time(s)", words[i], counts[i]);
                    }
                }
                Console.WriteLine("Operation done.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("The file cannot be loaded.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The argument passed to a method is incorrect.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory does not exist.");
            }
            finally
            {
                Console.ReadKey();
            }
        }
        static void CountWords(string word)
        {
            int count = 0;
            int len = word.Length;
            for (int i = 0; i < file.Length - len; i++)
            {
                string tmp = file.Substring(i, len);
                if (tmp == word)
                {
                    count++;
                }
            }
            counts.Add(count);
        }
        static void SortCounts()
        {
            for (int i = 0; i < counts.Count; i++)
            {
                for (int j = i; j < counts.Count; j++)
                {
                    if (counts[j] > counts[i])
                    {
                        int tmp = counts[j];
                        counts[j] = counts[i];
                        counts[i] = tmp;
                        string temp = words[j];
                        words[j] = words[i];
                        words[i] = temp;
                    }
                }
            }
        }
    }
}
