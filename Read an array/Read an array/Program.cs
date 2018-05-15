using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Read_an_array
{
    class Program
    {
        static int[,] array;
        static int size;
        static StreamReader read = new StreamReader("test.txt");
        static StreamWriter write = new StreamWriter("Sample.txt");
        static void Main(string[] args)
        {
            try
            {
                using (read)
                {
                    using (write)
                    {
                        size = Int32.Parse(read.ReadLine());
                        array = new int[size, size];
                        ParseArray();
                        int sum = FindSubArray();
                        PrintArray();
                        write.WriteLine("The sum of the file is {0}.", sum);
                        Console.WriteLine("The sum of the file is {0}.", sum);
                        
                        Console.ReadKey();
                    }
                }
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

        static void PrintArray()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(" | ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j]);
                    if (j < size - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write(" | ");
                Console.WriteLine();
            }
        }
        static void ParseArray()
        {
            for (int i = 0; i < size; i++)
            {
                string line = read.ReadLine();
                string[] values = line.Split(' ');
                ParseRow(values, i);
            }
        }
        
        static void ParseRow(string[] values, int row)
        {
            int[] holder = new int[size];
            for (int i = 0; i < size; i++)
            {
                holder[i] = int.Parse(values[i]);
                array[row, i] = holder[i];
            }
        }

        static int FindSubArray()
        {
            int sum = 0;
            for (int row = 0; row < size - 1; row++)
            {
                for (int col = 0; col < size - 1; col++)
                {
                    int temp = array[row, col] + array[row, col + 1] +
                        array[row + 1, col] + array[row + 1, col + 1];
                    if (temp > sum)
                    {
                        sum = temp;
                    }
                }
            }
            return sum;
        }
    }
}
