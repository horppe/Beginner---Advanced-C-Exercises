using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_area_of_a_Triangle
{
    class Program
    {
        static TriangleArea trngle = new TriangleArea();
        static void Main(string[] args)
        {
            Console.WriteLine("The Area of a triangle.");
            Console.WriteLine("Enter 1 to Calculate area of triangle with size of three sides: ");
            Console.WriteLine("Enter 2 to calculate with side and altitude to it: ");
            Console.WriteLine("Enter 3 to  calsulate with two sides and angle between them: ");
            Console.Write("Enter number: ");
            int swt = int.Parse(Console.ReadLine());
            double result = 0d;
            switch (swt)        //Switches between three three operations.
            {
                case 1:
                    result = GetThreeSides(); break;
                case 2: result = GetBaseAltitude(); break;
                case 3: result = trngle.SideAngle(); break;
            }
            Console.WriteLine("The area of the triangle is {0}", result);
            Console.ReadKey();
        }

        static double GetThreeSides()
        {
            Console.Write("Enter a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            double b = double.Parse(Console.ReadLine());        //Gets values for the first and third formular, all three sides a, b, c.
            Console.Write("Enter c: ");
            double c = double.Parse(Console.ReadLine());
            return trngle.ThreeSides(a, b, c);
        }
        static double GetBaseAltitude()
        {
            Console.Write("Enter Base 'b': ");
            double b = double.Parse(Console.ReadLine());        //Gets the values for the second formular.
            Console.Write("Enter altitude 'a': ");
            double a = double.Parse(Console.ReadLine());
            return trngle.BaseAltitude(a, b);
        }
    }
    
    class TriangleArea
    {
        public double ThreeSides(double a, double b, double c)
        {
            double p = (a + b + c) / 2;     //This formular gets the Half of the sum of all sides as the area.
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public double BaseAltitude(double a, double b)
        {
            return (b * a) / 2;     //This formular returns half of the sum of the base and the altitude as the area.
        }
        public double SideAngle()
        {
            Console.Write("Enter a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            double b = double.Parse(Console.ReadLine());        //Gets values for the third formular, all three sides a, b, c.
            Console.Write("Enter c: ");
            double c = Math.Sin(double.Parse(Console.ReadLine()));
            c *= -1;
            double result = (a * b * c) / 2;
            return result;
        }
    }
}
