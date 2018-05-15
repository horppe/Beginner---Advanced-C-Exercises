using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stream_Try_Catch_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

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
    }
}
