using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Sort the student in descending order by their branch using query syntax
            Console.WriteLine("Sort the student in descending order by their branch using query syntax");
            var querySyntax = from student in Student.GetAllStudents()
                              orderby student.Branch descending
                              select student;

            foreach (var student in querySyntax)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.FirstName + " " + student.LastName + ", Branch: " + student.Branch);
            }

            // Sort the student in descending order by their branch using method syntax
            Console.WriteLine("\nSort the student in descending order by their branch using method syntax");
            var methodSyntax = Student.GetAllStudents().OrderByDescending(student => student.Branch).ToList();

            foreach (var student in methodSyntax)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.FirstName + " " + student.LastName + ", Branch: " + student.Branch);
            }

            // Sort the student in descending order by first name whose branch is CSE using query syntax
            Console.WriteLine("\nSort the student in descending order by first name whose branch is CSE using query syntax");

            var querySyntax1 = from student in Student.GetAllStudents()
                                where student.Branch.ToUpper() == "CSE"
                                orderby student.FirstName descending
                                select student;

            foreach (var student in querySyntax1)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.FirstName + " " + student.LastName + ", Branch: " + student.Branch);
            }

            // Sort the student in descending order by first name whose branch is CSE using method syntax
            Console.WriteLine("\nSort the student in descending order by first name whose branch is CSE using method syntax");

            var methodSyntax1 = Student.GetAllStudents().Where(std => std.Branch.ToUpper() == "CSE").OrderByDescending(std => std.FirstName).ToList();

            foreach (var student in methodSyntax1)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.FirstName + " " + student.LastName + ", Branch: " + student.Branch);
            }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }

        public static List<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student{ID= 101,FirstName = "Preety",LastName = "Tiwary",Branch = "CSE"},
                new Student{ID= 102,FirstName = "Preety",LastName = "Agrawal",Branch = "ETC"},
                new Student{ID= 103,FirstName = "Priyanka",LastName = "Dewangan",Branch = "ETC"},
                new Student{ID= 104,FirstName = "Hina",LastName = "Sharma",Branch = "ETC"},
                new Student{ID= 105,FirstName = "Anugrag",LastName = "Mohanty",Branch = "CSE"},
                new Student{ID= 106,FirstName = "Anurag",LastName = "Sharma",Branch = "CSE"},
                new Student{ID= 107,FirstName = "Pranaya",LastName = "Kumar",Branch = "CSE"},
                new Student{ID= 108,FirstName = "Manoj",LastName = "Kumar",Branch = "ETC"},
                new Student{ID= 109,FirstName = "Pranaya",LastName = "Rout",Branch = "ETC"},
                new Student{ID= 110,FirstName = "Saurav",LastName = "Rout",Branch = "CSE"}
            };
        }
    }
}