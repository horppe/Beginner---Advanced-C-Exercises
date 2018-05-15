using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Read_a_list_of_names
{
    class Program
    {

        static StreamReader reader;
        static StreamWriter writer;
        static List<string> names = new List<string>();
        static void Main(string[] args)
        {
            try
            {
                reader = new StreamReader("test.txt");
                writer = new StreamWriter("Sample.txt");
                using (reader)
                {
                    using (writer)
                    {
                        while (!reader.EndOfStream)     //Get the names from the file
                        {
                            names.Add(reader.ReadLine());
                        }
                        Console.WriteLine("Names from the first file");
                        PrintNames();
                        SortNames();        //Sort the names in the List<string>
                        for (int i = 0; i < names.Count; i++)
                        {
                            writer.WriteLine(names[i]);     //Write names in another txt file
                        }
                        Console.WriteLine("Sorted names:");
                        PrintNames();
                        Console.ReadKey();
                    }
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("We are at the last line of the text file");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("The file might be damaged");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file is not at the specified directory");
            }

        }
        
        static void SortNames()
        {
            for (int i = 0; i < names.Count; i++)
            {
                for (int j = i; j < names.Count; j++)
                {
                    string holderI = names[i]; //Hold the comparison strings
                    string holderJ = names[j];
                    if (holderJ[0] < holderI[0] )    //If j-string is lower than I-string
                    {                                //they are swapped
                        names[i] = holderJ;
                        names[j] = holderI;
                    }
                }
            }
        }

        static void PrintNames()
        {
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(" {0} ", names[i]);
            }
            Console.WriteLine();
        }
    }
}
