using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xor_encryption
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter message to encrypt:");
                string text = Console.ReadLine();
                Console.WriteLine("Input the message Key:");
                string key = Console.ReadLine();
                string encrypted = Encrypt(text, key);
                Console.WriteLine("The encrypted message is:\r\n{0}", encrypted);
                Console.WriteLine("The decrypted message is:\r\n{0}", Encrypt(encrypted, key));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The argument passed to the Encrypt method/function is not valid");
            }
            finally
            {
                Console.ReadKey();
            }
        }
        static string Encrypt(string text, string key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0, j = 0; i < text.Length; i++, j++)
            {
                if (j == key.Length)
                {
                    j = 0;
                }
                byte x = (byte)text[i];
                byte y = (byte)key[j];
                int res = (byte)(x ^ y);
                sb.Append((char)res);
            }
            return sb.ToString();
        }
    }
}
