using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Is all students have total marks greater than 250 using Method Syntax
            Console.WriteLine("Is all students have total marks greater than 250 using Method Syntax");
            var methodSyntax = Student.GetAllStudnets().All(s => s.TotalMarks > 250);
            Console.WriteLine("All students have total marks greater than 250 using Method Syntax: " + methodSyntax);

            // Is all students have total marks greater than 250 using Query Syntax
            Console.WriteLine("\nIs all students have total marks greater than 250 using Query Syntax");
            var querySyntax = (from s in Student.GetAllStudnets()
                               select s).All(s => s.TotalMarks > 250);
            Console.WriteLine("All students have total marks greater than 250 using Query Syntax: " + querySyntax);


            // Find all the students who have marks in each subject greater than 80 using Method Syntax
            Console.WriteLine("\nFind all the students who have marks in each subject greater than 80 using Method Syntax");
            var methodSyntax1 = Student.GetAllStudnets().Where(s => s.Subjects.All(su => su.Marks > 80));
            foreach (var student in methodSyntax1)
            {
                Console.WriteLine("Student ID: " + student.ID + ", Student Name: " + student.Name);
                foreach (var subject in student.Subjects)
                {
                    Console.WriteLine("Subject: " + subject.SubjectName + ", Marks: " + subject.Marks);
                }
            }

            // Find all the students who have marks in each subject greater than 80 using Query Syntax
            Console.WriteLine("\nFind all the students who have marks in each subject greater than 80 using Query Syntax");
            var querySyntax1 = from s in Student.GetAllStudnets()
                               where s.Subjects.All(su => su.Marks > 80)
                               select s;
            foreach (var student in querySyntax1)
            {
                Console.WriteLine("Student ID: " + student.ID + ", Student Name: " + student.Name);
                foreach (var subject in student.Subjects)
                {
                    Console.WriteLine("Subject: " + subject.SubjectName + ", Marks: " + subject.Marks);
                }
            }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
        public List<Subject> Subjects { get; set; }
        public static List<Student> GetAllStudnets()
        {
            List<Student> listStudents = new List<Student>()
            {
                new Student{ID= 101,Name = "Preety", TotalMarks = 265,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 80},
                        new Subject(){SubjectName = "Science", Marks = 90},
                        new Subject(){SubjectName = "English", Marks = 95}
                    }},
                new Student{ID= 102,Name = "Priyanka", TotalMarks = 278,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 90},
                        new Subject(){SubjectName = "Science", Marks = 95},
                        new Subject(){SubjectName = "English", Marks = 93}
                    }},
                new Student{ID= 103,Name = "James", TotalMarks = 240,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 70},
                        new Subject(){SubjectName = "Science", Marks = 80},
                        new Subject(){SubjectName = "English", Marks = 90}
                    }},
                new Student{ID= 104,Name = "Hina", TotalMarks = 275,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 90},
                        new Subject(){SubjectName = "Science", Marks = 90},
                        new Subject(){SubjectName = "English", Marks = 95}
                    }},
                new Student{ID= 105,Name = "Anurag", TotalMarks = 255,
                    Subjects = new List<Subject>()
                    {
                        new Subject(){SubjectName = "Math", Marks = 80},
                        new Subject(){SubjectName = "Science", Marks = 90},
                        new Subject(){SubjectName = "English", Marks = 85}
                    }
                },
            };
            return listStudents;
        }
    }
    public class Subject
    {
        public string SubjectName { get; set; }
        public int Marks { get; set; }
    }
}