using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            //Sorting the Student data by First Name and Last Name in Descending Order using Query Syntax
            Console.WriteLine("Sorting the Student data by First Name and Last Name in Descending Order using Query Syntax");
            var querySyntax = from student in Student.GetAllStudents()
                                orderby student.FirstName, student.LastName descending
                                select student;

            foreach (var student in querySyntax)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.FirstName + " " + student.LastName + ", Branch: " + student.Branch);
            }

            //Sorting the Student data by First Name and Last Name in Descending Order using Method Syntax
            Console.WriteLine("\nSorting the Student data by First Name and Last Name in Descending Order using Method Syntax");
            var methodSyntax = Student.GetAllStudents()
                                .OrderBy(student => student.FirstName)
                                .ThenByDescending(student => student.LastName)
                                .ToList();
            
            foreach (var student in methodSyntax)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.FirstName + " " + student.LastName + ", Branch: " + student.Branch);
            }

            //First Sort Students in Ascending Order Based on Branch. Then Sort Students in Descending Order Based on FirstName. Finally Sort Students in Ascending Order Based on LastName
            Console.WriteLine("\nFirst Sort Students in Ascending Order Based on Branch. Then Sort Students in Descending Order Based on FirstName. Finally Sort Students in Ascending Order Based on LastName");
            var querySyntax1 = from student in Student.GetAllStudents()
                                orderby student.Branch, student.FirstName descending, student.LastName
                                select student;

            foreach (var student in querySyntax1)
            {
                Console.WriteLine("ID: " + student.ID + ", Name: " + student.FirstName + " " + student.LastName + ", Branch: " + student.Branch);
            }

            //First Sort Students in Ascending Order Based on Branch. Then Sort Students in Descending Order Based on FirstName. Finally Sort Students in Ascending Order Based on LastName
            Console.WriteLine("\nFirst Sort Students in Ascending Order Based on Branch. Then Sort Students in Descending Order Based on FirstName. Finally Sort Students in Ascending Order Based on LastName");
            var methodSyntax1 = Student.GetAllStudents()
                                .OrderBy(student => student.Branch)
                                .ThenByDescending(student => student.FirstName)
                                .ThenBy(student => student.LastName)
                                .ToList();

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