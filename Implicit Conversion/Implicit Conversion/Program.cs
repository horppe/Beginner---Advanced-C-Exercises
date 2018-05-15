using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implicit_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog firstDog = "Samson";
            Dog secondDog = "Biodun";
            Dog tempDog = firstDog + secondDog;
            Dog bastard = new Dog("Bastard", 1);
        }
    }

    class Dog
    {
        private string dogName;
        private int dogAge;
        private string DogName
        {
            set { this.dogName = value; }
        }
        private int DogAge
        {
            set { this.dogAge = value; }
        }
        public static Dog operator + ( Dog a, Dog b)
        {
            return new Dog(string.Format("{0} and {1}'s Child", a.dogName, b.dogName), 1);
        }
        
        public static implicit operator Dog(string dogName)
        {
            return new Dog(dogName);
        }
        public static implicit operator Dog(int dogAge)
        {
            return new Dog(dogAge);
        }
        public Dog(): this("Unknown dog", 0)
        {

        }
        public Dog(int age) : this("Unknown dog", age)
        {

        }
        public Dog(string name) : this(name, 0)
        {

        }
        public Dog(string name, int age)
        {
            dogName = name;
            dogAge = age;
        }
    }
}
