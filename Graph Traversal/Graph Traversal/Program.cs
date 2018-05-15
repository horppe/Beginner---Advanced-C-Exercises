using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Traversal_Algorithm
{
    class Program
    {
        static string[,] lab =
                {   //Labrynth
                { "0","0","0","x","0","x"},
                { "0","x","0","x","0","x"},
                { "0","*","x","0","x","0"},
                { "0","x","0","0","0","0"},
                { "0","0","0","x","x","0"},
                { "0","0","0","x","0","x"}
                };
        static Queue<string> que = new Queue<string>();

        static void Main(string[] args)
        {
            try
            {   //First enqueue the coordinates to the start point
                que.Enqueue(string.Format("{0},{1}", 2, 1));
                lab[2, 1] = "0";    //Change start position to count value for further use to increment other cells.
                while (que.Count > 0)
                {
                    string[] strCoord = que.Dequeue().Split(',');
                    int x = int.Parse(strCoord[0]);
                    int y = int.Parse(strCoord[1]); //Make the string coordinates operable by spliting and parsing it.
                    int count = int.Parse(lab[x, y]);
                    count++;    //count is gotten from the current cell, parsed and incremented.
                    List<string> cells = GetCells(x, y);   //Call method GetCells to return a List containing the next depth of cells.
                    for (int i = 0; i < cells.Count; i++)
                    {
                        string[] tmpCoord = cells[i].Split(',');
                        int tmpX = int.Parse(tmpCoord[0]);
                        int tmpY = int.Parse(tmpCoord[1]);  //Convert cells by parsing
                        lab[tmpX, tmpY] = count.ToString(); //and use converted cells to input current count.ToString()
                        que.Enqueue(string.Format("{0},{1}", tmpX, tmpY));  //Enqueue string format of next depth of cells.
                    }
                }
                lab[2, 1] = "*"; //Return start position to default value after all operations on it.
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was an exception.");
            }
            FillEmptyCells(); //This method fills the remaining empty cells with the string value "u"
            PrintGraph();
            Console.ReadKey();
        }

        static List<string> GetCells(int x, int y)
        {
            List<string> list = new List<string>();
            list.Add(Traverse(x + 1, y));
            list.Add(Traverse(x, y + 1));
            list.Add(Traverse(x - 1, y));
            list.Add(Traverse(x, y - 1));   //Traverse every direction of Labrynth for empty cells.
            List<string> result = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != string.Empty)
                {   //Filter out empty strings and Add the rest of the cells to result
                    result.Add(list[i]);
                }
            }
            return result;  //Return result
        }

        static string Traverse(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return string.Empty;
            }

            if (x > lab.GetLength(0) - 1 || y > lab.GetLength(1) - 1)
            {
                return string.Empty;
            }

            if (lab[x, y] == "x")
            {
                return string.Empty;
            }

            if (lab[x, y] == "0")
            {   //Return string format of empty cell, else return empty string
                return string.Format("{0},{1}", x, y);
            }
            else
            {
                return string.Empty;
            }
        }

        static void FillEmptyCells()
        {
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    if (lab[i, j] == "0")
                    {   //Fill empty cells with value "u"
                        lab[i, j] = "u";
                    }
                }
            }
        }

        static void PrintGraph()
        {   //Print the full graph
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    Console.Write(lab[i, j]);
                    if (j < lab.GetLength(1) - 1)
                    {
                        Console.Write("    ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
