using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex_to_Dec_and_Bin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hexForm = new int[20];
            hexForm[0] = 1;
            for (int i = 1; i < hexForm.Length; i++)
            {
                int k = i, temp = 1;                     //Populate the powers of 16 for the Hexadecimal calculation
                while (k >= 1)
                {
                    temp *= 16;
                    k--;
                }
                hexForm[i] = temp;
            }

            Console.Write("Enter Hex value: ");
            string hexa = Console.ReadLine();        //Read the Hex value from the console.
            int[] hex = new int[hexa.Length];
            for (int i = 0; i < hexa.Length; i++)
            {
                switch (hexa[i])
                {
                    case '1': hex[i] = 1;
                        break;
                    case '2': hex[i] = 2;
                        break;
                    case '3': hex[i] = 3;           //Switch the Hex values with the Decimal replacement.
                        break;
                    case '4': hex[i] = 4;
                        break;
                    case '5': hex[i] = 5;
                        break;
                    case '6': hex[i] = 6;
                        break;
                    case '7': hex[i] = 7;
                        break;
                    case '8': hex[i] = 8;
                        break;
                    case '9': hex[i] = 9;
                        break;
                    case 'A': hex[i] = 10;
                        break;
                    case 'B': hex[i] = 11;
                        break;
                    case 'C': hex[i] = 12;
                        break;
                    case 'D': hex[i] = 13;
                        break;
                    case 'E': hex[i] = 14;
                        break;
                    case 'F': hex[i] = 15;
                        break;
                }
            }
            int result = 0;
            for (int i = 0, j = hex.Length - 1; i < hex.Length; i++)
            {
                result += hex[j--] * hexForm[i];         //Calculate the Decimal value.
            }
            Console.Write("The Decimal value is {0}.", result);
            int[] bin = new int[4];
            List<int> binArray = new List<int>();
            for (int i = hex.Length - 1; i >= 0; i--)
            {
                int f = hex[i];
                int tmp = 0;
                int k = 0;
                for (int a = 0; a < bin.Length; a++)
                {
                    bin[a] = 0;       //Initialize the size 4 array with values of zeroes.
                }
                while (f > 0)
                {
                    tmp = f % 2;
                    f /= 2;
                    if ((tmp == 1) || (tmp == 0))  //Populate the array with ones and zeroes as the binary digits.
                    {
                        bin[k++] = tmp;
                    }
                }
                for (int b = 0; b < bin.Length; b++)
                {
                    binArray.Add(bin[b]);          //Add all the 4 bits binary digits to binArray.
                }
            }
            Console.WriteLine();
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("The Binary value is ");
            for (int i = binArray.Count - 1; i >= 0; i--)
            {
                Console.Write(binArray[i] + " ");      //Print the binArray list.
            }

            Console.ReadKey();
        }
    }
}
