using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Select the data as it is using Query Syntax
            Console.WriteLine("Select the data as it is using Query Syntax");
            var basicQuery = (from emp in Employee.GetEmployees()
                              select emp).ToList();

            foreach (var emp in basicQuery)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.FirstName} {emp.LastName}, Salary: {emp.Salary}");
            }

            // Select the data as it is using Method Syntax
            Console.WriteLine("\nSelect the data as it is using Method Syntax");

            var basicMethod = Employee.GetEmployees().ToList();

            foreach (var emp in basicMethod)
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.FirstName} {emp.LastName}, Salary: {emp.Salary}");
            }

            // Select only a single property using Query Syntax
            Console.WriteLine("\nSelect only a single property using Query Syntax");

            var basicQuery1 = (from emp in Employee.GetEmployees()
                               select emp.FirstName).ToList();
            
            foreach (var emp in basicQuery1)
            {
                Console.WriteLine($"Name: {emp}");
            }

            // Select only a single property using Method Syntax
            Console.WriteLine("\nSelect only a single property using Method Syntax");
            var basicMethod1 = Employee.GetEmployees().Select(emp => emp.FirstName).ToList();

            foreach (var emp in basicMethod1)
            {
                Console.WriteLine($"Name: {emp}");
            }

            // Select a Few Properties to a Different class using Query Syntax
            Console.WriteLine("\nSelect a Few Properties to a Different class using Query Syntax");
            
            var basicQuery2 = (from emp in Employee.GetEmployees()
                               select new EmployeeDTO
                               {
                                   Name = emp.FirstName + " " + emp.LastName,
                                   Salary = emp.Salary
                               }).ToList();

            foreach (var emp in basicQuery2)
            {
                Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
            }

            // Select a Few Properties to a Different class using Method Syntax
            Console.WriteLine("\nSelect a Few Properties to a Different class using Method Syntax");
            var basicMethod2 = Employee.GetEmployees().Select(emp => new EmployeeDTO
            {
                Name = emp.FirstName + " " + emp.LastName,
                Salary = emp.Salary
            }).ToList();

            foreach (var emp in basicMethod2)
            {
                Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee {ID = 101, FirstName = "Preety", LastName = "Tiwary", Salary = 60000 },
                new Employee {ID = 102, FirstName = "Priyanka", LastName = "Dewangan", Salary = 70000 },
                new Employee {ID = 103, FirstName = "Hina", LastName = "Sharma", Salary = 80000 },
                new Employee {ID = 104, FirstName = "Anurag", LastName = "Mohanty", Salary = 90000 },
                new Employee {ID = 105, FirstName = "Sambit", LastName = "Satapathy", Salary = 100000 },
                new Employee {ID = 106, FirstName = "Sushanta", LastName = "Jena", Salary = 160000 }
            };
        }
    }

    public class EmployeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}