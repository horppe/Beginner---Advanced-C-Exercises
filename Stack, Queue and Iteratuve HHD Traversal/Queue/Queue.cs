using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stack__Queue_and_Iteratuve_HHD_Traversal
{
    class Queue
    {
        static void Main(string[] args)
        {
            Queue<string> que = new Queue<string>();
            que.Enqueue(@"C:\");
            while (que.Count > 0)
            {
                try
                {
                    string currentDir = que.Dequeue();
                    Console.WriteLine(currentDir);
                    string[] folders = Directory.GetDirectories(currentDir);
                    for (int i = 0; i < folders.Length; i++)
                    {
                        que.Enqueue(folders[i]);
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
