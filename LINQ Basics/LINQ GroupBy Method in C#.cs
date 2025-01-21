using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Group students by branch using Method Syntax
            Console.WriteLine("Group students by branch using Method Syntax");
            var methodSyntax = Student.GetStudents().GroupBy(s => s.Barnch);
            foreach (var group in methodSyntax)
            {
                Console.WriteLine("Branch: " + group.Key + ", Count: " + group.Count());
                foreach (var student in group)
                {
                    Console.WriteLine("Student ID: " + student.ID + ", Student Name: " + student.Name);
                }
            }

            // Group students by branch using Query Syntax
            Console.WriteLine("\nGroup students by branch using Query Syntax");
            var querySyntax = from s in Student.GetStudents()
                              group s by s.Barnch into g
                              select new { Branch = g.Key, Students = g };
            foreach (var group in querySyntax)
            {
                Console.WriteLine("Branch: " + group.Branch + ", Count: " + group.Students.Count());
                foreach (var student in group.Students)
                {
                    Console.WriteLine("Student ID: " + student.ID + ", Student Name: " + student.Name);
                }
            }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Barnch { get; set; }
        public int Age { get; set; }
        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student { ID = 1001, Name = "Preety", Gender = "Female", Barnch = "CSE", Age = 20 },
                new Student { ID = 1002, Name = "Snurag", Gender = "Male", Barnch = "ETC", Age = 21  },
                new Student { ID = 1003, Name = "Pranaya", Gender = "Male", Barnch = "CSE", Age = 21  },
                new Student { ID = 1004, Name = "Anurag", Gender = "Male", Barnch = "CSE", Age = 20  },
                new Student { ID = 1005, Name = "Hina", Gender = "Female", Barnch = "ETC", Age = 20 },
                new Student { ID = 1006, Name = "Priyanka", Gender = "Female", Barnch = "CSE", Age = 21 },
                new Student { ID = 1007, Name = "santosh", Gender = "Male", Barnch = "CSE", Age = 22  },
                new Student { ID = 1008, Name = "Tina", Gender = "Female", Barnch = "CSE", Age = 20  },
                new Student { ID = 1009, Name = "Celina", Gender = "Female", Barnch = "ETC", Age = 22 },
                new Student { ID = 1010, Name = "Sambit", Gender = "Male",Barnch = "ETC", Age = 21 }
            };
        }
    }
}