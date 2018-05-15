using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_S_D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int nTwo = n;                                 //Input the values
            Console.Write("Enter S: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Enter D: ");
            int d = int.Parse(Console.ReadLine());
            int temp = 0, swt = 0;
            
            List<char> nArray = new List<char>();
            List<int> intArray = new List<int>();
            while (n > 0)
            {
                if (s < 16)
                {
                    temp = n % s;
                    n /= s;                                //Convert S to Base s
                    intArray.Add(temp);
                    swt = 1;
                }
                else if (s == 16)
                {
                    temp = n % s;
                    n /= s;
                    swt = 2;
                    switch (temp)
                    {
                        case 1:
                            nArray.Add('1'); break;
                        case 2:
                            nArray.Add('2'); break;
                        case 3:
                            nArray.Add('3'); break;
                        case 4:
                            nArray.Add('4'); break;
                        case 5:
                            nArray.Add('5'); break;
                        case 6:
                            nArray.Add('6'); break;
                        case 7:
                            nArray.Add('7'); break;
                        case 8:
                            nArray.Add('8'); break;
                        case 9:
                            nArray.Add('9'); break;
                        case 10:
                            nArray.Add('A'); break;
                        case 11:
                            nArray.Add('B'); break;
                        case 12:
                            nArray.Add('C'); break;
                        case 13:
                            nArray.Add('D'); break;
                        case 14:
                            nArray.Add('E'); break;
                        case 15:
                            nArray.Add('F'); break;
                    }
                }
            }

            
            Console.Write("The Base {0} value is: ", s);
            if (swt == 2)
            {
                for (int i = nArray.Count - 1; i >= 0; i--)  //Print the Base s values
                {
                    Console.Write(nArray[i] + " ");
                }
            }
            else if (swt == 1)
            {
                for (int i = intArray.Count - 1; i >= 0; i--)
                {
                    Console.Write(intArray[i] + " ");
                }
            }
            Console.WriteLine();

            swt = 0;
            List<int> dintArray = new List<int>();
            List<char> dCharArray = new List<char>();
            while (nTwo > 0)
            {
                if (d < 16)
                {
                    swt = 1;
                    temp = nTwo % d;                          //Convert D to Base d
                    nTwo /= d;                
                    dintArray.Add(temp);
                }
                else if (d == 16)
                {
                    swt = 2;
                    temp = nTwo % d;
                    nTwo /= d;
                    switch (temp)
                    {
                        case 1:
                            dCharArray.Add('1'); break;
                        case 2:
                            dCharArray.Add('2'); break;
                        case 3:
                            dCharArray.Add('3'); break;
                        case 4:
                            dCharArray.Add('4'); break;
                        case 5:
                            dCharArray.Add('5'); break;
                        case 6:
                            dCharArray.Add('6'); break;
                        case 7:
                            dCharArray.Add('7'); break;
                        case 8:
                            dCharArray.Add('8'); break;
                        case 9:
                            dCharArray.Add('9'); break;
                        case 10:
                            dCharArray.Add('A'); break;
                        case 11:
                            dCharArray.Add('B'); break;
                        case 12:
                            dCharArray.Add('C'); break;
                        case 13:
                            dCharArray.Add('D'); break;
                        case 14:
                            dCharArray.Add('E'); break;
                        case 15:
                            dCharArray.Add('F'); break;
                    }
                }
            }

            Console.Write("The Base {0} value is: ", d);
            if (swt == 1)
            {
                for (int i = dintArray.Count - 1; i >= 0; i--)
                {                                                     //Print the Base d values
                    Console.Write(dintArray[i] + " ");
                }
            }
            else if (swt == 2)
            {
                for (int i = dCharArray.Count - 1; i >= 0; i--)
                {
                    Console.Write(dCharArray[i] + " ");
                }
            }

            /*
            int[] dArray = new int[16];
            dArray[0] = 1;
            temp = 1;
            for (int i = 1; i < dArray.Length; i++)   //Algorithm to populate the base D array values.
            {
                dArray[i] = (temp *= s);
            }
            */
            Console.ReadKey();
        }
    }
}
