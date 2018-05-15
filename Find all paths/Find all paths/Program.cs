using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_all_paths
{
    class Program
    {
        static char[,] lab = 
        {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        static void Main(string[] args)
        {
            char[] dir = new char[20];
            FindPath(0, 0, 'S', dir, 0);
            Console.ReadKey();
        }
        static void PrintDir(char[] dir)
        {
            Console.WriteLine("Congrats!!!, You are out of the Maze");
            for (int i = 0; i < dir.Length; i++)
            {
                if (dir[i] == ' ')
                {
                    break;
                }
                Console.Write(dir[i] + " ");
            }
            Console.WriteLine();
        }
        static void FindPath(int row, int col, char ind, char[] dir, int pos)
        {
            if ((row < 0 || col < 0) || (row > lab.GetLength(0) - 1 || col > lab.GetLength(1) - 1))
            {       //If index is out of array, then return
                return;
            }

            if (lab[row,col] == 'e')
            {
                dir[pos] = 'E';
                PrintDir(dir);
                return;
            }
            
            if (lab[row,col] != ' ')
            {       //If index is not free, then return
                return;
            }
            
            if (lab[row,col] == ' ')
            {
                lab[row, col] = 'v';
            }
            dir[pos] = ind;
            FindPath(row, col - 1, 'L', dir, pos + 1);         //Left
            FindPath(row + 1, col, 'D', dir, pos + 1);         //Down
            FindPath(row - 1, col, 'U', dir, pos + 1);         //Up
            FindPath(row, col + 1, 'R', dir, pos + 1);         //Right

            lab[row, col] = ' ';            //Change the index back to its previous state after going through it.
            return;
        }
    }
}
