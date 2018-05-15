using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat
{
    public class Cat
    {
        private int serial;
        public int Serial
        {
            get
            {
                return this.serial;
            }

            set
            {
                this.serial = value;
            }
        }

        public int CatSerial(int serial)
        {
            this.serial = serial;
            return this.serial;
        }

        public void SayMiau()
        {
            Console.WriteLine("Cat {0} said: Miauuuuuu!", this.serial);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Cat[] someCat = new Cat[10];
            for (int i = 0; i < someCat.Length; i++)
            {
                int randomSer = rnd.Next(0, 50) + 1;
                someCat[i] = new Cat();
                someCat[i].Serial = randomSer;
            }
            for (int i = 0; i < someCat.Length; i++)
            {
                someCat[i].SayMiau();
            }
            Console.ReadKey();
        }
    }
}
