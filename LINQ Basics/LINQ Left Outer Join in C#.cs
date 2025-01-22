using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Left Outer Join using Method Syntax
            Console.WriteLine("Left Outer Join using Method Syntax");
            var leftOuterJoinMethodSyntax = Employee.GetAllEmployees()
                .GroupJoin(Address.GetAddress(),
                emp => emp.AddressId,
                addr => addr.ID,
                (emp, addr) => new
                {
                    Employee = emp,
                    Address = addr.FirstOrDefault()
                });

            foreach (var item in leftOuterJoinMethodSyntax)
            {
                Console.WriteLine("Employee ID: " + item.Employee.ID + ", Employee Name: " + item.Employee.Name + ", Address: " + (item.Address == null ? "No Address" : item.Address.AddressLine));
            }

            // Left Outer Join using Query Syntax
            Console.WriteLine("\nLeft Outer Join using Query Syntax");
            var leftOuterJoinQuerySyntax = from emp in Employee.GetAllEmployees()
                                           join addr in Address.GetAddress()
                                           on emp.AddressId equals addr.ID into employeeGroup
                                           from addr in employeeGroup.DefaultIfEmpty()
                                           select new
                                           {
                                               Employee = emp,
                                               Address = addr
                                           };

            foreach (var item in leftOuterJoinQuerySyntax)
            {
                Console.WriteLine("Employee ID: " + item.Employee.ID + ", Employee Name: " + item.Employee.Name + ", Address: " + (item.Address == null ? "No Address" : item.Address.AddressLine));
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", AddressId = 1},
                new Employee { ID = 2, Name = "Priyanka", AddressId =2},
                new Employee { ID = 3, Name = "Anurag", AddressId = 0},
                new Employee { ID = 4, Name = "Pranaya", AddressId = 0},
                new Employee { ID = 5, Name = "Hina", AddressId = 5},
                new Employee { ID = 6, Name = "Sambit", AddressId = 6}
            };
        }
    }

    public class Address
    {
        public int ID { get; set; }
        public string AddressLine { get; set; }
        public static List<Address> GetAddress()
        {
            return new List<Address>()
            {
                new Address { ID = 1, AddressLine = "AddressLine1"},
                new Address { ID = 2, AddressLine = "AddressLine2"},
                new Address { ID = 5, AddressLine = "AddressLine5"},
                new Address { ID = 6, AddressLine = "AddressLine6"},
            };
        }
    }
}