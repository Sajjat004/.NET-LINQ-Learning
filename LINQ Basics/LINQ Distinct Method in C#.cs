using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test{
        public static void Main() 
        {
            // Get the distinct name of the students using Query Syntax
            Console.WriteLine("Get the distinct name of the students using Query Syntax");
            var querySyntax = (from student in Student.GetStudents()
                               select student.Name)
                               .Distinct().ToList();

            foreach (var name in querySyntax)
            {
                Console.WriteLine(name);
            }

            // Get the distinct name of the students using Method Syntax
            Console.WriteLine("\nGet the distinct name of the students using Method Syntax");
            var methodSyntax = Student.GetStudents()
                                .Select(std => std.Name)
                                .Distinct().ToList();

            foreach (var name in methodSyntax)
            {
                Console.WriteLine(name);
            }

            // Get the distiict name and ID of the students using Query Syntax
            Console.WriteLine("\nGet the distiict name and ID of the students using Query Syntax");
            var querySyntax1 = (from student in Student.GetStudents()
                                select new { student.ID, student.Name })
                                .Distinct().ToList();
            
            foreach (var student in querySyntax1)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.Name);
            }

            // Get the distiict name and ID of the students using Method Syntax
            Console.WriteLine("\nGet the distiict name and ID of the students using Method Syntax");
            var methodSyntax1 = Student.GetStudents()
                                .Select(std => new { std.ID, std.Name })
                                .Distinct().ToList();

            foreach (var student in methodSyntax1)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.Name);
            }

            // We can also get the distinct name and ID of the students using the DistinctBy method by overriding the Equals and GetHashCode method in the Student class. If we don't override the Equals and GetHashCode method in the Student class then it will compare the reference of the object and return the distinct object.
            
            // Console.WriteLine("\nWe can also get the distinct name and ID of the students using the DistinctBy method by overriding the Equals and GetHashCode method in the Student class");
            // var distinctStudents = Student.GetStudents().Distinct().ToList();
            // foreach (var student in distinctStudents)
            // {
            //     Console.WriteLine("ID: " + student.ID + ", Name: " + student.Name);
            // }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student {ID = 101, Name = "Preety" },
                new Student {ID = 102, Name = "Sambit" },
                new Student {ID = 103, Name = "Hina"},
                new Student {ID = 104, Name = "Anurag"},
                new Student {ID = 102, Name = "Sambit"},
                new Student {ID = 103, Name = "Hina"},
                new Student {ID = 101, Name = "Preety" },
            };
        }

        // public override bool Equals(object obj)
        // {
        //     if (obj == null || !(obj is Student))
        //     {
        //         return false;
        //     }
        //     return this.ID == ((Student)obj).ID && this.Name == ((Student)obj).Name;
        // }

        // public override int GetHashCode()
        // {
        //     return this.ID.GetHashCode() ^ this.Name.GetHashCode();
        // }
    }
}