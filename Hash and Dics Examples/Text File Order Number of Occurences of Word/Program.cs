using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_File_Order_Number_of_Occurences_of_Word
{
    class Program
    {
        static string text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
        static void Main(string[] args)
        {
            char[] symbols = { '?', ' ', ',', '.', '/', '–', '!'};
            string[] words = text.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            IDictionary<string, int> dict = new SortedDictionary<string, int>(new CaseInsensitiveComparer());
            dict =  GetFrequency(words);
            Console.ReadKey();
        }

        class CaseInsensitiveComparer : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                return string.Compare(s1, s2, true);
            }
        }

        static Dictionary<string, int> GetFrequency(string[] array)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].ToLower();
            }
            
            foreach (string value in array)
            {
                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict[value] = 1;
                }
            }
            return dict;
        }

    }
}
