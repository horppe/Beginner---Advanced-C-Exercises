using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Read_a_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName1 = @"C:\Users\sammx\Desktop\Note very important.txt";
            string fileName2 = @"C:\Users\sammx\Desktop\test.txt";
            //string writeName = @"C:\Users\sammx\Desktop\new.txt";
            StreamReader read1 = new StreamReader(fileName1);
            StreamReader read2 = new StreamReader(fileName2);
            using (read1)
            {
                using (read2)
                {
                    int equalCounter = 0;
                    int difCounter = 0;
                    while (!read1.EndOfStream || !read2.EndOfStream)
                    {
                        string first = read1.ReadLine();
                        string second = read2.ReadLine();
                        if (first.Length == second.Length)
                        {
                            equalCounter++;
                        }
                        else
                        {
                            difCounter++;
                        }
                    }
                    Console.WriteLine("There is {0} equal lines and {1} unequal lines in the two text files.", equalCounter, difCounter);
                }
            }
            
            Console.ReadKey();
        }
        
    }
}
