using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_sequence_of_equal_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] array = {
                                {"ho", "fifi", "xh", "hi"},
                                {"kx", "fifi", "x", "kx"},
                                {"xxx", "fifi", "h", "xx"}
                              };
            int place = 0;
            int counter = 0;
            int bin = 0;
            
            for (int i = 0; i < 1; i++)
            {
                for (int j = array.GetLength(0) - 1; j >= 2; j--)
                {
                    if ((array[i, j] == array[i + 1, j - 1]) && (array[i + 1, j - 1] == array[i + 2, j - 2]))
                    {
                        place = j;
                        bin = 1;
                    }
                }
            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < array.GetLength(0) - 2; j++)
                {
                    if ((array[i, j] == array[i + 1, j + 1]) && (array[i + 1, j + 1] == array[i + 2, j + 2]))
                    {
                        place = j;
                        bin = 2;
                    }
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[counter, 0] == array[i,j])
                    {
                        place = counter;
                        bin = 3;
                    }
                }
                counter++;
            }

            counter = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 1; j < array.GetLength(0); j++)
                {
                    if (array[0, counter] == array[j, i])
                    {
                        place = counter;
                        bin = 4;
                    }
                }
                counter++;
            }

            switch (bin)
            {
                case 0: Console.WriteLine("Sorry. There is no Sequence in this Matrix");
                    break;
                case 1:
                    for (int i = 0; i <= 0; i++)
                    {
                        for (int j = place; j <= place; j++)
                        {
                            Console.Write(array[i, j] + " ");
                            Console.Write(array[i + 1, j - 1] + " ");
                            Console.Write(array[i + 2, j - 2] + " ");
                        }
                        break;
                    }
                    break;
                case 2:
                    for (int i = 0; i <= 0; i++)
                    {
                        for (int j = place; j <= place; j++)
                        {
                            Console.Write(array[i, j] + " ");
                            Console.Write(array[i + 1, j + 1] + " ");
                            Console.Write(array[i + 2, j + 2] + " ");
                        }
                    }
                    break;
                case 3:
                    for (int i = place; i <= place; i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            Console.Write(array[i, j] + " ");
                        }
                    }
                    break;
                case 4:
                    for (int i = place; i <= place; i++)
                    {
                        for (int j = 0; j < array.GetLength(0); j++)
                        {
                            Console.Write(array[j, i] + " ");
                        }
                    }
                    break;
            }

            Console.ReadKey();
        }
    }
}
