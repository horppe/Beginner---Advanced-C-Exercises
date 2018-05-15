using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman_to_Arabic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Roman digits: ");
            string roman = Console.ReadLine();
            int temp = 0;
            int[] romanNum = new int[roman.Length];
            for (int i = 0; i < roman.Length; i++)
            {
                switch (roman[i])
                {
                    case 'I': romanNum[i] = 1;
                        break;
                    case 'V': romanNum[i] = 5;
                        break;
                    case 'X': romanNum[i] = 10;
                        break;
                    case 'L': romanNum[i] = 50;
                        break;
                    case 'C': romanNum[i] = 100;
                        break;
                    case 'D': romanNum[i] = 500;
                        break;
                    case 'M': romanNum[i] = 1000;
                        break;
                }
            }
            int tempTwo = 0;
            for (int i = 0; i < romanNum.Length; i++)
            {
                if ((i >= 1))
                {
                    if (romanNum[i] > romanNum[i - 1])
                    {
                        temp = romanNum[i] - temp;
                        continue;
                    }
                }
                temp += romanNum[i];

            }

            string arabic = Convert.ToString(temp);
            char[] arabicNum = new char[arabic.Length];
            for (int i = 0; i < arabic.Length; i++)
            {
                switch (arabic[i])
                {
                    case '0':
                        arabicNum[i] = '٠';
                        break;
                    case '1':
                        arabicNum[i] = '١';
                        break;
                    case '2':
                        arabicNum[i] = '٢';
                        break;
                    case '3':
                        arabicNum[i] = '٣';
                        break;
                    case '4':
                        arabicNum[i] = '٣';
                        break;
                    case '5':
                        arabicNum[i] = '٥';
                        break;
                    case '6':
                        arabicNum[i] = '٦';
                        break;
                    case '7':
                        arabicNum[i] = '٧';
                        break;
                    case '8':
                        arabicNum[i] = '٨';
                        break;
                    case '9':
                        arabicNum[i] = '٩';
                        break;
                }
            }

            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("The Arabic Value is: : ");
            for (int i = 0; i < arabicNum.Length; i++)
            {
                Console.Write(arabicNum[i] + " ");
            }


            Console.ReadKey();
        }
    }
}
