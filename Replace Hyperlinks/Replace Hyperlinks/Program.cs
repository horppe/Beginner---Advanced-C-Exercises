using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Replace_Hyperlinks
{
    class Program
    {
        static List<string> file = new List<string>();
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader("Sample.html"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        ReplaceLink(line);
                    }
                }
                using (StreamWriter writer = new StreamWriter("Sample.html"))
                {
                    for (int i = 0; i < file.Count; i++)
                    {
                        writer.WriteLine(file[i]);
                    }
                }
                Console.WriteLine("All Hyperlinks have been replaced with [URL=][/URL].\r\nOperation Completed.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("There might be something wrong with the file name or extension given.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Acces to the file was denied by system administrator.");
            }
            finally
            {
                Console.ReadKey();
            }
        }
        
        static void ReplaceLink(string line)
        {
            string pat1 = @"<a href=\s?""";
            string pat2 = @""">";
            string pat3 = @"</a>";
            string rep = Regex.Replace(line, pat1, "[URL=");
            rep = Regex.Replace(rep, pat2, "]");
            rep = Regex.Replace(rep, pat3, "[/URL]");
            file.Add(rep);
        }
    }
}
