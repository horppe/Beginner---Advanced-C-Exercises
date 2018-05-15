using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parse_dictionary
{
    class Program
    {
        static IDictionary<string, string> dic = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            try
            {
                ParseDictionary();
                Interface();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The data type sent to the method/function is not valid.");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The word cannot be found in the Dictionary");
            }
            finally
            {
                Console.ReadKey();
            }

        }
        
        static void Interface()
        {
            Console.Write("Input word: ");
            string word = Console.ReadLine().Trim();
            if (dic.ContainsKey(word))
            {
                Console.WriteLine(dic[word]);
            }
            if (dic.ContainsKey(word.ToLower()))
            {
                Console.WriteLine(dic[word.ToLower()]);
            }
            if (dic.ContainsKey(word.ToUpper()))
            {
                Console.WriteLine(dic[word.ToUpper()]);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
        static void ParseDictionary()
        {
            string data = ".NET – platform for applications from Microsoft\r\n"+
                            "CLR – managed execution environment for .NET\r\n"+
                            "namespace – hierarchical organization of classes";
            string[] array = data.Split('\r', '\n');
            char[] trimChars = { ' ', '\r', '\n' };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "")
                {
                    continue;
                }
                string[] word = array[i].Split((char)8211);
                dic.Add(word[0].Trim(), word[1].Trim());
            }
        }
    }
}
