using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Delete_all_odd_lines_in_file
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> acc = new List<string>();
                using (StreamReader reader = new StreamReader("Sample.txt"))
                {
                    int counter = 1;
                    while (!reader.EndOfStream)  //While the ReadLine stream is not at the end
                    {
                        string word = reader.ReadLine();
                        if (counter % 2 == 0)   //If the line(counter) is only even, add to list
                        {
                            acc.Add(word);
                        }
                        counter++;
                    }
                }
                using (StreamWriter writer = new StreamWriter("Sample.txt"))
                {
                    for (int i = 0; i < acc.Count; i++)  //Overwrite the file with the acquired list
                    {
                        writer.WriteLine(acc[i]);
                    }
                    Console.WriteLine("All the odd lines have been deleted."); //Confirmation message
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
    }
}
