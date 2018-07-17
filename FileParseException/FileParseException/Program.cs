using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParseException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = "test.txt";
                StreamReader stream = new StreamReader(path);
                using (stream)
                {
                    int line = 1;
                    int parse;
                    while (!stream.EndOfStream)
                    {
                        // If the line recieved from the stream 
                        // is not Parsable
                     
                        if (!int.TryParse(stream.ReadLine(), out parse))
                        {
                            throw new FileParseException(path, line);
                        }
                        line++;
                    }
                }
            }
            catch (FileParseException fpe)
            {
                fpe.Message();
                Console.ReadLine();
            }

        }
    }
    class FileParseException: Exception
    {
        private string fileName;
        private int rowNumber;
        
        new public void Message()
        {
            Console.WriteLine("The character at line {0} in file {1} cannot be Parsed", rowNumber, fileName);
        }

        public FileParseException(string name, int line)
        {
            this.fileName = name;
            this.rowNumber = line;
        }
    }
}
