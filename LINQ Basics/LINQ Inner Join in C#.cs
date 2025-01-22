using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Inner join between Employee and Address using Query Syntax
            Console.WriteLine("Inner join between Employee and Address using Query Syntax");
            var querySyntax = from emp in Employee.GetAllEmployees()
                                join addr in Address.GetAllAddresses()
                                on emp.AddressId equals addr.ID
                                select new EmployeeAddress
                                {
                                    EmployeeName = emp.Name,
                                    AddressLine = addr.AddressLine
                                };

            foreach (var employee in querySyntax)
            {
                Console.WriteLine("Employee Name: " + employee.EmployeeName + ", Address Line: " + employee.AddressLine);
            }

            // Inner join between Employee and Address using Method Syntax
            Console.WriteLine("\nInner join between Employee and Address using Method Syntax");
            var methodSyntax = Employee.GetAllEmployees()
                                .Join(Address.GetAllAddresses(),
                                emp => emp.AddressId,
                                addr => addr.ID,
                                (emp, addr) => new EmployeeAddress
                                {
                                    EmployeeName = emp.Name,
                                    AddressLine = addr.AddressLine
                                });
        
            foreach (var employee in methodSyntax)
            {
                Console.WriteLine("Employee Name: " + employee.EmployeeName + ", Address Line: " + employee.AddressLine);
            }

            // Note: Optimized way to join two collections is to use the Join method. The Join method is more efficient than the SelectMany method. We can also use parallel LINQ (PLINQ) to improve the performance of the Join method. Here is an example of using PLINQ with the Join method.
            // var methodSyntax1 = Employee.GetAllEmployees()
            //                     .AsParallel()
            //                     .Join(Address.GetAllAddresses(),
            //                     emp => emp.AddressId,
            //                     addr => addr.ID,
            //                     (emp, addr) => new EmployeeAddress
            //                     {
            //                         EmployeeName = emp.Name,
            //                         AddressLine = addr.AddressLine
            //                     });
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
                new Employee { ID = 1, Name = "Preety", AddressId = 1 },
                new Employee { ID = 2, Name = "Priyanka", AddressId = 2 },
                new Employee { ID = 3, Name = "Anurag", AddressId = 3 },
                new Employee { ID = 4, Name = "Pranaya", AddressId = 4 },
                new Employee { ID = 5, Name = "Hina", AddressId = 5 },
                new Employee { ID = 6, Name = "Sambit", AddressId = 6 },
                new Employee { ID = 7, Name = "Happy", AddressId = 7},
                new Employee { ID = 8, Name = "Tarun", AddressId = 8 },
                new Employee { ID = 9, Name = "Santosh", AddressId = 9 },
                new Employee { ID = 10, Name = "Raja", AddressId = 10},
                new Employee { ID = 11, Name = "Sudhanshu", AddressId = 11}
            };
        }
    }

    public class Address
    {
        public int ID { get; set; }
        public string AddressLine { get; set; }

        public static List<Address> GetAllAddresses()
        {
            return new List<Address>()
            {
                new Address { ID = 1, AddressLine = "AddressLine1"},
                new Address { ID = 2, AddressLine = "AddressLine2"},
                new Address { ID = 3, AddressLine = "AddressLine3"},
                new Address { ID = 4, AddressLine = "AddressLine4"},
                new Address { ID = 5, AddressLine = "AddressLine5"},
                new Address { ID = 9, AddressLine = "AddressLine9"},
                new Address { ID = 10, AddressLine = "AddressLine10"},
                new Address { ID = 11, AddressLine = "AddressLine11"},
            };
        }
    }

    class EmployeeAddress
    {
        public string EmployeeName { get; set; }
        public string AddressLine { get; set; }
    }
}