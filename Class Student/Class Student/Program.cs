using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Student
{
    class Student
    {
        private static int studentCount;
        private string firstName, secondName, course, subject, university, email, phoneNo;

        public int Count
        {
            get { return studentCount; }
        }

        public string FullName
        {
            get { return this.firstName + " " + this.secondName; }
        }

        public string Course
        {
            get { return this.course; }
        }

        public string Subject
        {
            get { return this.subject; }
        }
        public string School
        {
            get { return this.university; }
        }
        public string Contact
        {
            get { return string.Format("My email: {0}, Phone number: {1}", this.email, this.phoneNo); }
        }

        public Student(): this(null)
        {}

        public Student(string firstName)
            : this(firstName, null)
        {}

        public Student(string firstName, string secondName) 
            : this(firstName, secondName, null)
        {}

        public Student(string firstName, string secondName, string course) 
            : this(firstName, secondName, course, null)
        {}

        public Student(string firstName, string secondName, string course, string subject) 
            : this(firstName, secondName, course, subject, null)
        {}

        public Student(string firstName, string secondName, string course, string subject, string university) 
            : this(firstName, secondName, course, subject, university, null)
        {}

        public Student(string firstName, string secondName, string course, string subject, string university, string email)
            : this(firstName, secondName, course, subject, university, email, null)
        {}

        public Student(string firstName, string secondName, string course, string subject, string university, string email, string phoneNo)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.course = course;
            this.subject = subject;
            this.university = university;
            this.email = email;
            this.phoneNo = phoneNo;
            studentCount++;
        }

        public void Introduce()
        {
            Console.WriteLine("Hello my name is {0} and i am current studying {1} in {2} university", this.FullName, this.course, this.university);
            Console.WriteLine("I am on a subject called {0}", this.subject);
            Console.WriteLine("My email is {0} and my phone is {1}", this.email, this.phoneNo);
            Console.WriteLine();
        }

        public class StudentTest
        {
            private static Student[] students;
            public int Count
            {
                get { return students.Length; }
            }
            public Student this[int index]
            {
                get { return students[index]; }
                set { students[index] = value; }
            }
            static StudentTest()
            {
                Student[] studentArray = new Student[20];
                for (int i = 0; i < studentArray.Length; i++)
                {
                    studentArray[i] = new Student(string.Format("Student number {0}.", i + 1));
                }
                students = studentArray;
            }
            
            public static bool TestStudent(Student person)
            {
                List<string> test = new List<string>();
                test.Add(person.firstName);
                test.Add(person.secondName);
                test.Add(person.course);
                test.Add(person.subject);
                test.Add(person.university);
                test.Add(person.email);
                test.Add(person.phoneNo);
                foreach (string info in test)
                {
                    if (info == null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student samson = new Student("Samson", "Oluokun");
            if (Student.StudentTest.TestStudent(samson))
            {
                Console.WriteLine("{0} is a complete student.", samson.FullName);
            }
            else
            {
                Console.WriteLine("{0} is not complete student.", samson.FullName);
            }
            Student.StudentTest st = new Student.StudentTest();
            for (int i = 0; i < st.Count; i++)
            {
                st[i].Introduce();
            }
            Console.ReadKey();
        }
    }
}
