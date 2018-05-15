using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Delete_word_Test
{
    class Program
    {
        static List<string> file = new List<string>();
        static string word;
        static string line;
        static void Main(string[] args)
        {
            Console.Write("Enter Word to delete from file: ");
            word = Console.ReadLine();
            try
            {
                StreamReader reader = new StreamReader("Sample.txt");
                using (reader)
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        EvalString();
                    }
                }
                StreamWriter writer = new StreamWriter("Sample.txt");
                using (writer)
                {
                    for (int i = 0; i < file.Count; i++)
                    {
                        writer.WriteLine(file[i]);
                    }
                }
                Console.WriteLine("{0} was successfully deleted from the text file.", word);
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
        static void EvalString()
        {
            int n = word.Length;
            for (int i = 0; i < line.Length - n; i++)
            {
                string tmp = line.Substring(i, n);
                if (tmp == word)
                {
                    if (CheckWord(i, i + (n - 1)))
                    {
                        DeleteWord(i, i + n);
                    }
                    else
                    {
                        if (line[i + (n - 1)] == '.')
                        {
                            line = line.Remove(i - 1, n);
                        }
                        else
                        {
                            line = line.Remove(i, n);
                        }
                    }
                }
            }
            file.Add(line);
        }
        static bool CheckWord(int strt, int end)
        {
            int i = 0, j = 0;
            int swt = 0;
            if ((strt > 0) && (line[strt - 1] == ' '))
            {
                swt = 1;
            }
            if (line[end + 1] == ' ' || line[end + 1] == '.')
            {
                swt = 1;
            }
            else
            {
                swt = 2;
            }

            if (swt == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        static void DeleteWord(int strt, int end)
        {
            while (strt > 0 && line[strt] != ' ')
            {
                strt--;
                if (strt > 0 && line[strt] == ' ')
                {
                    strt++;
                    break;
                }
            }
            while (end < line.Length && line[end] != ' ')
            {
                end++;
                if (end < line.Length && line[end] == ' ')
                {
                    break;
                }
            }
            int count = end - strt;
            line = line.Remove(strt, count);
        }
    }
}
