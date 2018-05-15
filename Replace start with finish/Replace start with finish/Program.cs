using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Replace_start_with_finish
{
    class Program
    {
        static string[] sepWord;
        static void Main(string[] args)
        {
            try
            {
                string word;
                StreamReader stream = new StreamReader("Sample.txt");
                using (stream)
                {
                    word = stream.ReadToEnd();
                    
                }
                sepWord = word.Split(' ');
                ReplaceWords(sepWord);
                string result = BuildWord();
                StreamWriter writer = new StreamWriter("Sample.txt");
                using (writer)
                {
                    writer.WriteLine(result);
                    Console.WriteLine("File edited.");
                }
                Console.ReadKey();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The File cannot be found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("The file might be corrupted.");
            }
        }
        static void ReplaceWords(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                switch (words[i])
                {
                    case "Start":
                        words[i] = "Finsh";
                        break;
                    case "start":
                        words[i] = "finish";
                        break;
                }
            }
        }
        static string BuildWord()
        {
            string word = null;
            for (int i = 0; i < sepWord.Length; i++)
            {
                word += sepWord[i] + " ";
            }
            return word;
        }
    }
}
