using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantissa_Sign_Exponent
{
    class Program
    {
        static void Main(string[] args)
        {
            float floatPoint = float.Parse(Console.ReadLine());
            byte[] data;
            data = System.BitConverter.GetBytes(floatPoint);
            List<int> binArray = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                while (data[i] > 0)
                {
                    int temp = data[i] % 2;
                    data[i] /= 2;
                    binArray.Add(temp);
                }
            }

            for (int i = 0; i < binArray.Count; i++)
            {
                Console.Write(binArray[i] + " ");
            }
        }
    }
}
