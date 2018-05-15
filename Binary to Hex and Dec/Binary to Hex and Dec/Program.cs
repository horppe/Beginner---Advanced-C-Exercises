using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_to_Hex_and_Dec
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bin = { 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0 };
            int j = bin.Length - 1;
            int[] binArray = new int[bin.Length];
            binArray[0] = 1;
            for (int k = 1; k < binArray.Length; k++)
            {
                int i = 1;
                int f = k;
                while (f >= 1)
                {
                    i *= 2;
                    f--;
                }
                binArray[k] = i;
            }
            int temp = 0;
            for (int k = bin.Length - 1, m = 0; k >= 0; k--, m++)
            {
                temp += bin[k] * binArray[m];
            }
            Console.WriteLine("The Decimal value is {0}", temp); //Print the Decimal value
            List<char> hex = new List<char>();
            int count = 0;
            while (temp > 0)
            {
                count = temp % 16;
                temp /= 16;
                switch (count)
                {
                    case 1:
                        hex.Add('1');
                        break;
                    case 2:
                        hex.Add('2');
                        break;
                    case 3:
                        hex.Add('3');           
                        break;
                    case 4:
                        hex.Add('4');
                        break;
                    case 5:
                        hex.Add('5');
                        break;
                    case 6:
                        hex.Add('6');
                        break;
                    case 7:
                        hex.Add('7');
                        break;
                    case 8:
                        hex.Add('8');
                        break;
                    case 9:
                        hex.Add('9');
                        break;
                    case 10:
                        hex.Add('A');
                        break;
                    case 11:
                        hex.Add('B');
                        break;
                    case 12:
                        hex.Add('C');
                        break;
                    case 13:
                        hex.Add('D');
                        break;
                    case 14:
                        hex.Add('E');
                        break;
                    case 15:
                        hex.Add('F');
                        break;
                }
            }
            Console.Write("The Hexadecimal value is ");
            for (int i = hex.Count - 1; i >= 0; i--)
            {
                Console.Write(hex[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
