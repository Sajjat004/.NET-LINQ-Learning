using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Sum of all salaries using Query Syntax
            Console.WriteLine("Sum of all salaries using Query Syntax");
            var querySyntax = (from emp in Employee.GetAllEmployees()
                               select emp).Sum(emp => emp.Salary);
            Console.WriteLine("Sum of all Salaries: " + querySyntax);

            // Sum of all salaries using Method Syntax
            Console.WriteLine("\nSum of all salaries using Method Syntax");
            var methodSyntax = Employee.GetAllEmployees().Sum(emp => emp.Salary);
            Console.WriteLine("Sum of all Salaries: " + methodSyntax);

            // Sum of all salaries of IT department using Query Syntax
            Console.WriteLine("\nSum of all salaries of IT department using Query Syntax");
            var querySyntax1 = (from emp in Employee.GetAllEmployees()
                                where emp.Department == "IT"
                                select emp).Sum(emp => emp.Salary);
            Console.WriteLine("Sum of all Salaries of IT department: " + querySyntax1);

            // Sum of all salaries of IT department using Method Syntax
            Console.WriteLine("\nSum of all salaries of IT department using Method Syntax");
            var methodSyntax1 = Employee.GetAllEmployees().Where(emp => emp.Department == "IT").Sum(emp => emp.Salary);
            // var methodSyntax1 = Employee.GetAllEmployees().Sum(emp => emp.Department == "IT" ? emp.Salary : 0);
            Console.WriteLine("Sum of all Salaries of IT department: " + methodSyntax1);
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listStudents = new List<Employee>()
            {
                new Employee{ID= 101,Name = "Preety", Salary = 10000, Department = "IT"},
                new Employee{ID= 102,Name = "Priyanka", Salary = 15000, Department = "Sales"},
                new Employee{ID= 103,Name = "James", Salary = 50000, Department = "Sales"},
                new Employee{ID= 104,Name = "Hina", Salary = 20000, Department = "IT"},
                new Employee{ID= 105,Name = "Anurag", Salary = 30000, Department = "IT"},
                new Employee{ID= 106,Name = "Sara", Salary = 25000, Department = "IT"},
                new Employee{ID= 107,Name = "Pranaya", Salary = 35000, Department = "IT"},
                new Employee{ID= 108,Name = "Manoj", Salary = 11000, Department = "Sales"},
                new Employee{ID= 109,Name = "Sam", Salary = 45000, Department = "Sales"},
                new Employee{ID= 110,Name = "Saurav", Salary = 25000, Department = "Sales"}
            };
            return listStudents;
        }
    }
}