using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Program
    {
        public static void Main()
        {
            // filter the employees whose salary is greater than 50000 using Query Syntax
            Console.WriteLine("Filter the employees whose salary is greater than 50000 using Query Syntax");
            var querySyntax = (from employees in Employee.GetEmployees()
                               where employees.Salary > 50000
                               select employees).ToList();
            
            foreach (var employee in querySyntax)
            {
                Console.WriteLine("ID: " + employee.ID + ", Name: " + employee.Name + ", Salary: " + employee.Salary);
            }

            // filter the employees whose salary is greater than 50000 using Method Syntax
            Console.WriteLine("\nFilter the employees whose salary is greater than 50000 using Method Syntax");
            var methodSyntax = Employee.GetEmployees().Where(emp => emp.Salary > 50000).ToList();

            foreach (var employee in methodSyntax)
            {
                Console.WriteLine("ID: " + employee.ID + ", Name: " + employee.Name + ", Salary: " + employee.Salary);
            }

            // filter the employees whose salary is greater than 500000 and gendar is male using Query Syntax
            Console.WriteLine("\nFilter the employees whose salary is greater than 500000 and gendar is male using Query Syntax");
            var querySyntax1 = from emp in Employee.GetEmployees()
                                where emp.Salary > 500000 && emp.Gender == "Male"
                                select emp; 

            foreach (var employee in querySyntax1)
            {
                Console.WriteLine("ID: " + employee.ID + ", Name: " + employee.Name + ", Gender: " + employee.Gender + ", Salary: " + employee.Salary);
            }

            // filter the employees whose salary is greater than 500000 and gendar is male using Method Syntax
            Console.WriteLine("\nFilter the employees whose salary is greater than 500000 and gendar is male using Method Syntax");
            var methodSyntax1 = Employee.GetEmployees().Where(emp => emp.Salary > 500000 && emp.Gender == "Male").ToList();

            foreach (var employee in methodSyntax1)
            {
                Console.WriteLine("ID: " + employee.ID + ", Name: " + employee.Name + ", Gender: " + employee.Gender + ", Salary: " + employee.Salary);
            }

            // Filter the employees with their index whose salary is greater than 50000 and gendar is male using Query Syntax
            Console.WriteLine("\nFilter the employees with their index whose salary is greater than 50000 and gendar is male using Query Syntax");
            var syntaxQuery = (from emp in Employee.GetEmployees()
                            .Select((data, index) => new {
                                employee = data,
                                Index = index
                            })
                            where emp.employee.Salary > 50000 && emp.employee.Gender == "Male"
                            select new {
                                EmployeeName = emp.employee.Name,
                                Gender = emp.employee.Gender,
                                Salary = emp.employee.Salary,
                                IndexPosition = emp.Index
                            }).ToList();

            foreach (var emp in syntaxQuery)
            {
                Console.WriteLine($"Position : {emp.IndexPosition} Name : {emp.EmployeeName}, Gender : {emp.Gender}, Salary : {emp.Salary}");
            }

            // Filter the employees with their index whose salary is greater than 50000 and gendar is male using Method Syntax
            Console.WriteLine("\nFilter the employees with their index whose salary is greater than 50000 and gender is male using Method Syntax");
            var methodSyntax2 = Employee.GetEmployees()
                                .Select((data, index) => new {
                                    employee = data,
                                    Index = index
                                })
                                .Where(emp => emp.employee.Salary > 50000 && emp.employee.Gender == "Male")
                                .Select (data => new {
                                    EmployeeName = data.employee.Name,
                                    Gender = data.employee.Gender,
                                    Salary = data.employee.Salary,
                                    IndexPosition = data.Index
                                })
                                .ToList();

            foreach (var emp in methodSyntax2)
            {
                Console.WriteLine($"Position : {emp.IndexPosition} Name : {emp.EmployeeName}, Gender : {emp.Gender}, Salary : {emp.Salary}");
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public List<string> Technology { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 101, Name = "Preety", Gender = "Female", Salary = 60000, Technology = new List<string>() {"C#", "Jave", "C++"} },
                new Employee { ID = 102, Name = "Priyanka", Gender = "Female", Salary = 50000, Technology =new List<string>() { "WCF", "SQL Server", "C#" } },
                new Employee { ID = 103, Name = "Hina", Gender = "Female", Salary = 40000, Technology =new List<string>() { "MVC", "Jave", "LINQ"}},
                new Employee { ID = 104, Name = "Anurag", Gender = "Male", Salary = 450000},
                new Employee { ID = 105, Name = "Sambit", Gender = "Male", Salary = 550000},
                new Employee { ID = 106, Name = "Sushanta", Gender = "Male", Salary = 700000, Technology =new List<string>() { "ADO.NET", "C#", "LINQ" }}
            };
        }
    }
}