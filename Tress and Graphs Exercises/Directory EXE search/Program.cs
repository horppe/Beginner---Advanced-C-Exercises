using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Directory_EXE_search
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Windows\");
            TraverseDir(root);
            Console.ReadKey();
        }

        static void TraverseDir(DirectoryInfo dir)
        {
            FileInfo[] files;
            try
            {
                 files = dir.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            foreach (FileInfo file in files)
            {
                string ext = file.Extension;
                bool match = ext == ".exe";
                if (match)
                {
                    Console.WriteLine(file.ToString());
                }
            }
            try
            {
                foreach (DirectoryInfo path in dir.GetDirectories())
                {
                    TraverseDir(path);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            
        }
    }

}
