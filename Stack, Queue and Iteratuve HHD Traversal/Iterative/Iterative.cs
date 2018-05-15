using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stack__Queue_and_Iteratuve_HHD_Traversal
{
    class Iterative
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetDirectories(@"C:\");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
                Traverse(files[i]);
            }
            Console.ReadKey();
        }
        static void Traverse(string path)
        {
            if (path == @"C:\users\sammx\AppData")
            {
                return;
            }
            string[] folders = null;

            try
            {
                folders = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            if (folders.Length <= 0)
            {
                return;
            }
            for (int i = 0; i < folders.Length; i++)
            {
                Console.WriteLine(folders[i]);
                Traverse(folders[i]);
            }
            return;
        }
    }
}
