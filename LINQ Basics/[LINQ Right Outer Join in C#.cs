using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Right Outer Join using Method Syntax
            Console.WriteLine("Right Outer Join using Method Syntax");
            var rightOuterJoinMS = Address.GetAddress()
                .GroupJoin(Employee.GetAllEmployees(),
                addr => addr.ID,
                emp => emp.AddressId,
                (addr, emp) => new
                {
                    Address = addr,
                    Employee = emp.FirstOrDefault()
                });

            
            foreach (var item in rightOuterJoinMS)
            {
                Console.WriteLine("Address: " + item.Address.AddressLine + ", Employee Name: " + item.Employee?.Name);
            }

            // Right Outer Join using Query Syntax
            Console.WriteLine("\nRight Outer Join using Query Syntax");
            var rightOuterJoinQS = (from addr in Address.GetAddress()
                                    join emp in Employee.GetAllEmployees()
                                    on addr.ID equals emp.AddressId into employeeGroup
                                    from e in employeeGroup.DefaultIfEmpty()
                                    select new
                                    {
                                        Address = addr,
                                        Employee = e
                                    });

            foreach (var item in rightOuterJoinQS)
            {
                Console.WriteLine("Address: " + item.Address.AddressLine + ", Employee Name: " + item.Employee?.Name);
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
