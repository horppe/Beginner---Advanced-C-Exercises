using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    class Class
    {
        private string classId;
        public List<Teacher> teachers = new List<Teacher>();
        public Class(string classId)
        {
            this.classId = classId;
        }

    }

    class Student
    {
        public string name;
        public int id;
        public Student(string name)
        {
            this.name = name;
        }
        public Student(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }

    class Teacher
    {
        public string name;
        public List<Discipline> discplines;
        public Teacher(string name, string discipline)
        {
            this.name = name;
            discplines = new List<Discipline>();
        }
        public Teacher(string name, string discipline, string discipline2)
        {
            this.name = name;

        }
        public Teacher(string name, string discipline, string discipline2, string discipline3)
        {
            this.name = name;

        }

    }
    class Discipline
    {
        public string name;
        public int noOfLessons;
        public int noOfExercises;
        public Discipline(string name, int noOfless, int noOfExer)
        {
            this.name = name;
            noOfLessons = noOfless;
            noOfExercises = noOfExer;
        }
    }
}
