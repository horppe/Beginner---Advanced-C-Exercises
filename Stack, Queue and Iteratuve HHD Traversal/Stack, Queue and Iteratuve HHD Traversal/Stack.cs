using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stack__Queue_and_Iteratuve_HHD_Traversal
{
    class Stack
    {
        static void Main(string[] args)
        {
            Stack<string> stk = new Stack<string>();
            stk.Push(@"C:\");
            while (stk.Count > 0)
            {
                try
                {
                    string currentDir = stk.Pop();
                    Console.WriteLine(currentDir);
                    string[] paths = Directory.GetDirectories(currentDir);
                    for (int i = 0; i < paths.Length; i++)
                    {
                        stk.Push(paths[i]);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }

            }
            Console.ReadKey();
        }
    }
}
