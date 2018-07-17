using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beta
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the code to get the Area, Diameter and Radius of a Circle.

            Console.WriteLine("Enter your respective values to get the Radius of a circle: ");
            Console.Write("Enter the Diameter Centimeter: ");

            double diameter = double.Parse(Console.ReadLine());
            double circumference = Math.PI * diameter;

            Console.WriteLine("The Perimeter of the circle is {0:#.#}", circumference);

            double c = circumference;
            double r = c / (2 * Math.PI);
            double area = Math.PI * (r * r);

            Console.WriteLine("The area of the circle is: {0:#.#}", area);
            Console.WriteLine("The Radius of the circle is: {0:#.#}", r);

            Console.ReadKey();
        }
    }
}
