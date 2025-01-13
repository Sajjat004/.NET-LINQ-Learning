using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }

    public class Test
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Gender = "Male"},
                new Student(){ID = 2, Name = "Sara", Gender = "Female"},
                new Student(){ID = 3, Name = "Steve", Gender = "Male"},
                new Student(){ID = 4, Name = "Pam", Gender = "Female"}
            };

            // LINQ query to fetch all setudents with gender male
            IQueryable<Student> maleStudents = students.AsQueryable().Where(student => student.Gender == "Male");

            // Iterate over the result
            foreach (var student in maleStudents)
            {
                Console.WriteLine("ID: {0}, Name: {1}, Gender: {2}", student.ID, student.Name, student.Gender);
            }
        }
    }
}