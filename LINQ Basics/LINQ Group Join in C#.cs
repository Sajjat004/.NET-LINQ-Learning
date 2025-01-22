using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Group employees by department using Method Syntax
            Console.WriteLine("Group employees by department using Method Syntax");
            var methodSyntax = Department.GetAllDepartments()
                                .GroupJoin(Employee.GetAllEmployees(),
                                dept => dept.ID,
                                emp => emp.DepartmentId,
                                (dept, emp) => new
                                {
                                    Department = dept.Name,
                                    Employees = emp
                                });

            foreach (var group in methodSyntax)
            {
                Console.WriteLine("Department: " + group.Department + ", Count: " + group.Employees.Count());
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine("Employee ID: " + employee.ID + ", Employee Name: " + employee.Name);
                }
            }

            // Group employees by department using Query Syntax
            Console.WriteLine("\nGroup employees by department using Query Syntax");
            var querySyntax = from dept in Department.GetAllDepartments()
                              join emp in Employee.GetAllEmployees()
                              on dept.ID equals emp.DepartmentId into employeeGroup
                              select new
                              {
                                  Department = dept.Name,
                                  Employees = employeeGroup
                              };

            foreach (var group in querySyntax)
            {
                Console.WriteLine("Department: " + group.Department + ", Count: " + group.Employees.Count());
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine("Employee ID: " + employee.ID + ", Employee Name: " + employee.Name);
                }
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", DepartmentId = 10},
                new Employee { ID = 2, Name = "Priyanka", DepartmentId =20},
                new Employee { ID = 3, Name = "Anurag", DepartmentId = 30},
                new Employee { ID = 4, Name = "Pranaya", DepartmentId = 30},
                new Employee { ID = 5, Name = "Hina", DepartmentId = 20},
                new Employee { ID = 6, Name = "Sambit", DepartmentId = 10},
                new Employee { ID = 7, Name = "Happy", DepartmentId = 10},
                new Employee { ID = 8, Name = "Tarun", DepartmentId = 0},
                new Employee { ID = 9, Name = "Santosh", DepartmentId = 10},
                new Employee { ID = 10, Name = "Raja", DepartmentId = 20},
                new Employee { ID = 11, Name = "Ramesh", DepartmentId = 30}
            };
        }
    }

    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<Department> GetAllDepartments()
        {
            return new List<Department>()
            {
                new Department { ID = 10, Name = "IT"},
                new Department { ID = 20, Name = "HR"},
                new Department { ID = 30, Name = "Sales"  },
            };
        }
    }
}