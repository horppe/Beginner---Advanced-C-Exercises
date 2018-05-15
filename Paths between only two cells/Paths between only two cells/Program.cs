using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paths_between_only_two_cells
{
    class Program
    {
        static char[,] lab = new char[100, 100];
        static void Main(string[] args)
        {
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    lab[i, j] = ' ';
                }
            }
            

            Console.ReadKey();
        }
        
    }
}
