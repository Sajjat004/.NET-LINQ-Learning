using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Program
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };
            var student2 = new Student() { ID = 102, Name = "Preety", TotalMarks = 375 };
            students.Add(student1);
            students.Add(student1);

            //Using Method Syntax
            var IsExistsMS = students.Contains(student1);
            
            //Using Query Syntax
            var IsExistsQS = (from num in students
                              select num).Contains(student1);
            Console.WriteLine(IsExistsMS);
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
    }
}


// Example 02
namespace Test
{
    public class Program
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){ID = 101, Name = "Priyanka", TotalMarks = 275 },
                new Student(){ID = 102, Name = "Preety", TotalMarks = 375 }
            };
            
            //Using Method Syntax
            var IsExistsMS = students.Contains(new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 });
            var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };
            //Using Query Syntax
            var IsExistsQS = (from num in students
                              select num).Contains(student1);
            Console.WriteLine(IsExistsMS);

            // Ooutput of this code will be False because Contains method will check the reference of the object and in this case, the reference of the object is different. But actually, the object is the same. So, the solution of this problem is the example 03
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
    }
}

// Example 03
namespace Test
{
    public class Program
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
                        {
                            new Student(){ID = 101, Name = "Priyanka", TotalMarks = 275 },
                            new Student(){ID = 102, Name = "Preety", TotalMarks = 375 }
                        };
            
            //Using Method Syntax
            var IsExistsMS = students.Contains(new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 });
            var student1 = new Student() { ID = 101, Name = "Priyanka", TotalMarks = 275 };
            //Using Query Syntax
            var IsExistsQS = (from num in students
                              select num).Contains(student1);
            Console.WriteLine(IsExistsMS);
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        public override bool Equals(object obj)
        {
            return this.ID == ((Student)obj).ID && this.Name == ((Student)obj).Name && this.TotalMarks == ((Student)obj).TotalMarks;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.Name.GetHashCode() ^ this.TotalMarks.GetHashCode();
        }
    }
}