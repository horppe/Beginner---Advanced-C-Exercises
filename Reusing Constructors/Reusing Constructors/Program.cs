using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusing_Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dg = new Dog("Samson", 21, 3.3);
        }
    }
    
    public class Collar
    {
        int size;
        public Collar()
        {

        }
        public Collar(int size)
        {
            this.size = size;
        }
    }
    public class Dog
    {
        string name;
        int age;
        double length;
        Collar collar;

        // No parameters
        public Dog()
        : this(null) // Constructor call
        {
            // More code could be added here
        }

        // One parameter
        public Dog(string name)
        : this(name, 0) // Constructor call
        {
        }

        // Two parameters
        public Dog(string name, int age)
        : this(name, age, 0.0) // Constructor call
        {
        }

        // Three parameters
        public Dog(string name, int age, double length)
        : this(name, age, length, new Collar()) // Constructor call
        {
        }

        // Four parameters
        public Dog(string name, int age, double length, Collar collar)
        {
            this.name = name;
            this.age = age;
            this.length = length;
            this.collar = collar;
        }
    }
}
