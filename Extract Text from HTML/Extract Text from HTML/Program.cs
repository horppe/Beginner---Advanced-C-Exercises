using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Extract_Text_from_HTML
{
    class Program
    {
        static List<string> file = new List<string>();
        static void Main(string[] args)
        {
            try
            {
                string text = File.ReadAllText("Sample.html");
                ExtractText(text);
                Console.ReadKey();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot find file.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("There is something wrong with the file Address.");
            }
        }

        static void ExtractText(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    if (CheckForward(text, i))
                    {
                        GetText(text, i + 1);
                    }
                }
            }
        }

        static bool CheckForward(string text, int pos)
        {
            if (pos != text.Length - 1 && text[pos + 1] != '<')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void GetText(string text, int pos)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = pos; i < text.Length; i++)
            {
                
                if (text[i] == '<')
                {
                    if (sb.Length <= 0)
                    {
                        return;
                    }
                    file.Add(sb.ToString());
                    return;
                }
                else
                {
                    if (text[i] == '\r' | text[i] == '\n')
                    {
                        continue;
                    }
                    else
                    {
                        sb.Append(text[i]);
                    }
                }
            }
        }
    }
}
