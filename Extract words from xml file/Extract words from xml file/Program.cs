using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Extract_words_from_xml_file
{
    class Program
    {
        static int strt = 0;
        static int end = 0;
        static List<string> list = new List<string>();
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader("Sample.xml"))
                {
                    string line = null;
                    while (!reader.EndOfStream)  //Iterate through each line of file
                    {
                        line = reader.ReadLine();
                        EvalString(line);  //Call the Evaluate string method
                    }
                    Console.WriteLine("The names in the xml file: ");
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                }
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
                Console.WriteLine("The File Path is incorrect.");
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

        static void EvalString(string word)
        {
            if (word[0] != '<')
            {                                  //If first character is not a tag
                if (CheckNextChar(word, 0))    //check if next char is or not a tag too
                {
                    strt = 0;               //Save current index in the Range variables.
                    GetLastIndex(word, 0);  //Call GetLastIndex method
                    AddToList(word);        //Call the Add to List method to use the range variables to add words or names
                }
            }
            GetRange(word, 0);
        }
        
        static void GetRange(string word, int pos)
        {
            if (pos == word.Length - 1)
            {
                return;
            }
            else
            {
                if (word[pos] == '>')       //If character is an 'End-Tag'
                {
                    if (CheckNextChar(word, pos))   //Check if next character is not a 'Start-tag'
                    {
                        strt = pos + 1;             //Save current index in Start range variable
                        GetLastIndex(word, pos);    //Get Last index of word
                        AddToList(word);            //Add word to Collection with the ranges from variable word
                    }
                }
                GetRange(word, pos + 1);
            }
        }

        static void AddToList(string word)
        {
            List<char> tempWord = new List<char>();     //List to hold individual chars
            for (int i = strt; i <= end; i++)
            {
                tempWord.Add(word[i]);                  //Add chars from ranges in word to tempWord list
            }
            string sendWord = null;                     //sendWord variable to gather every char in to form a word
            for (int i = 0; i < tempWord.Count; i++)
            {
                sendWord += tempWord[i];                //Forloop to add chars to sendWord
            }
            list.Add(sendWord);     //Add sendWord to collection(list) of words from xml file
        }

        static void GetLastIndex(string word, int start)    //Gets the last index of a word that ends with a 'Start-Tag'
        {
            for (int i = start; i < word.Length; i++)
            {
                if (word[i] == '<')     //If next index == 'Start-Tag'(<)
                {                       
                    end = i - 1;        //Save previous index to End range variable
                    return;
                }
            }
        }

        static bool CheckNextChar(string word, int index)    
        {
            if (index < word.Length - 1)        //If index is not too close to end of the string
            {
                if (word[index + 1] != '<' && word[index + 1] != ' ')
                {           // If index is not a 'Start-Tag' and is not an empty space char
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}
