using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {

        public static void Main()
        {
            // Select all programming languages using Query Syntax
            Console.WriteLine("Select all programming languages using Query Syntax");
            var querySyntax = (from student in Student.GetStudents()
                               from programming in student.Programming
                               select programming).ToList();
            
            Console.Write("All Programming Languages:");
            foreach (var programming in querySyntax)
            {
                Console.Write(" " + programming + ",");
            }
            Console.WriteLine();

            // Select all programming languages using Method Syntax
            Console.WriteLine("\nSelect all programming languages using Method Syntax");
            var methodSyntax = Student.GetStudents().SelectMany(student => student.Programming).ToList();

            Console.Write("All Programming Languages:");
            foreach (var programming in methodSyntax)
            {
                Console.Write(" " + programming + ",");
            }
            Console.WriteLine();

            // Select all distinct programming languages using Query Syntax
            Console.WriteLine("\nSelect all distinct programming languages using Query Syntax");
            var querySyntax1 = (from student in Student.GetStudents()
                                from programming in student.Programming
                                select programming).Distinct().ToList();

            Console.Write("All Distinct Programming Languages:");
            foreach (var programming in querySyntax1)
            {
                Console.Write(" " + programming + ",");
            }
            Console.WriteLine();

            // Select all distinct programming languages using Method Syntax
            Console.WriteLine("\nSelect all distinct programming languages using Method Syntax");
            var methodSyntax1 = Student.GetStudents().SelectMany(student => student.Programming).Distinct().ToList();

            Console.Write("All Distinct Programming Languages:");
            foreach (var programming in methodSyntax1)
            {
                Console.Write(" " + programming + ",");
            }
            Console.WriteLine();

            // select all the students with their programming languages using Query Syntax
            Console.WriteLine("\nSelect all the students with their programming languages using Query Syntax");
            var querySyntax2 = (from student in Student.GetStudents()
                                from program in student.Programming
                                select new 
                                {
                                    StudentName = student.Name,
                                    ProgramName = program
                                }).ToList();

            foreach (var student in querySyntax2)
            {
                Console.WriteLine($"Student Name: {student.StudentName}, Programming Language: {student.ProgramName}");
            }

            // select all the students with their programming languages using Method Syntax
            Console.WriteLine("\nSelect all the students with their programming languages using Method Syntax");
            var methodSyntax2 = Student.GetStudents().SelectMany(student => student.Programming,
                                (student, program) => new
                                {
                                    StudentName = student.Name,
                                    ProgramName = program
                                }).ToList();

            foreach (var student in methodSyntax2)
            {
                Console.WriteLine($"Student Name: {student.StudentName}, Programming Language: {student.ProgramName}");
            }
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public List<string> Programming { get; set; }

            public static List<Student> GetStudents()
            {
                return new List<Student>()
                {
                    new Student() {ID = 1, Name = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++"} },
                    new Student() {ID = 2, Name = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" }},
                    new Student() {ID = 3, Name = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ"} },
                    new Student() {ID = 4, Name = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
                };
            }
        }
    }
}