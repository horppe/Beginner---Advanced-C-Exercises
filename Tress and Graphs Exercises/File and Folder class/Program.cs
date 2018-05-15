using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_and_Folder_class
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo home = new DirectoryInfo(@"C:\Windows\");
            Folder root = new Folder(home.Name, home.GetFiles(), home.GetDirectories());
            List<string> subTreeSizes = new List<string>();
            Stack<Folder> stk = new Stack<Folder>();
            stk.Push(root);
            while (stk.Count > 0)
            {
                Folder currentPath = stk.Pop();
                List<File> files = currentPath.files;
                int mbSize = 0;
                foreach (File file in files)
                {
                    mbSize += file.MBSize;
                }
                subTreeSizes.Add(string.Format("Folder: {0}, Total Filesize: {1}MB", currentPath.name, mbSize));
                foreach (Folder child in currentPath.childFolders)
                {
                    stk.Push(child);
                }
            }

            foreach (string sum in subTreeSizes)
            {
                Console.WriteLine(sum);
            }
            Console.ReadKey();
        }
    }

    class File
    {
        public string name;
        private int size;
        public int MBSize { get { return (size / 1000000); } }
        public int KBSize { get { return (size / 1000); } }
        public File(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}MB, {2}KB, {3}Bytes", name, MBSize, KBSize, size);
        }
    }
    class Folder
    {
        public string name;
        public List<File> files;
        public List<Folder> childFolders;
        public Folder(string name)
        {
            this.name = name;
        }
        public Folder(string name, FileInfo[] files)
            : this(name)
        {
            this.files = new List<File>();
            foreach (FileInfo file in files)
            {
                this.files.Add(new File(file.Name, (int)file.Length));
            }
        }
        public Folder(string name, FileInfo[] files, DirectoryInfo[] children)
            : this(name, files)
        {
            childFolders = new List<Folder>();
            foreach (DirectoryInfo child in children)
            {
                try
                {
                    childFolders.Add(new Folder(child.Name, child.GetFiles(), child.GetDirectories()));
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
        }
    }
}
