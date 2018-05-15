using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog shelby = Dog.Instance;
            shelby.Introduce();
            Console.ReadKey();
        }
    }

    class Dog
    {
        private static Dog instance;
        private string name;
        private int age;
        private string color;
        private Dog(string name, int age, string color)
        {
            this.name = name;
            this.age = age;
            this.color = color;
        }

        public static Dog Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dog("Shelby", 3, "Brown");
                }
                return instance;
            }
        }

        public void Introduce()
        {
            Console.WriteLine("Hello my name is " + this.name + ", i am " + this.age + " years old and my color is " + this.color + ".");
        }
    }
}
