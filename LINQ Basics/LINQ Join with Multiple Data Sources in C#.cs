using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            // Inner join between Employee, Address, and Department using Query Syntax
            Console.WriteLine("Inner join between Employee, Address, and Department using Query Syntax");
            var querySyntax = from emp in Employee.GetAllEmployees()
                              join addr in Address.GetAllAddresses()
                              on emp.AddressId equals addr.ID
                              join dept in Department.GetAllDepartments()
                              on emp.DepartmentId equals dept.ID
                              select new EmployeeResult
                              {
                                  ID = emp.ID,
                                  EmployeeName = emp.Name,
                                  DepartmentName = dept.Name,
                                  AddressLine = addr.AddressLine
                              };

            foreach (var employee in querySyntax)
            {
                Console.WriteLine("ID: " + employee.ID + ", Employee Name: " + employee.EmployeeName + ", Department Name: " + employee.DepartmentName + ", Address Line: " + employee.AddressLine);
            }

            // Inner join between Employee, Address, and Department using Method Syntax
            Console.WriteLine("\nInner join between Employee, Address, and Department using Method Syntax");
            var methodSyntax = Employee.GetAllEmployees()
                                .Join(Address.GetAllAddresses(),
                                emp => emp.AddressId,
                                addr => addr.ID,
                                (emp, addr) => new { emp, addr })
                                .Join(Department.GetAllDepartments(),
                                empAddr => empAddr.emp.DepartmentId,
                                dept => dept.ID,
                                (empAddr, dept) => new EmployeeResult
                                {
                                    ID = empAddr.emp.ID,
                                    EmployeeName = empAddr.emp.Name,
                                    DepartmentName = dept.Name,
                                    AddressLine = empAddr.addr.AddressLine
                                });

            foreach (var employee in methodSyntax)
            {
                Console.WriteLine("ID: " + employee.ID + ", Employee Name: " + employee.EmployeeName + ", Department Name: " + employee.DepartmentName + ", Address Line: " + employee.AddressLine);
            }

            // Note: Optimized way to join two collections is to use the Join method. The Join method is more efficient than the SelectMany method. We can also use parallel LINQ (PLINQ) to improve the performance of the Join method. Here is an example of using PLINQ with the Join method.
            // var methodSyntax1 = Employee.GetAllEmployees()
            //                     .AsParallel()
            //                     .Join(Address.GetAllAddresses(),
            //                     emp => emp.AddressId,
            //                     addr => addr.ID,
            //                     (emp, addr) => new { emp, addr })
            //                     .Join(Department.GetAllDepartments(),
            //                     empAddr => empAddr.emp.DepartmentId,
            //                     dept => dept.ID,
            //                     (empAddr, dept) => new EmployeeResult
            //                     {
            //                         ID = empAddr.emp.ID,
            //                         EmployeeName = empAddr.emp.Name,
            //                         DepartmentName = dept.Name,
            //                         AddressLine = empAddr.addr.AddressLine
            //                     });

        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int DepartmentId { get; set; }

        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", AddressId = 1, DepartmentId = 10    },
                new Employee { ID = 2, Name = "Priyanka", AddressId = 2, DepartmentId =20   },
                new Employee { ID = 3, Name = "Anurag", AddressId = 3, DepartmentId = 30    },
                new Employee { ID = 4, Name = "Pranaya", AddressId = 4, DepartmentId = 0    },
                new Employee { ID = 5, Name = "Hina", AddressId = 5, DepartmentId = 0       },
                new Employee { ID = 6, Name = "Sambit", AddressId = 6, DepartmentId = 0     },
                new Employee { ID = 7, Name = "Happy", AddressId = 7, DepartmentId = 0      },
                new Employee { ID = 8, Name = "Tarun", AddressId = 8, DepartmentId = 0      },
                new Employee { ID = 9, Name = "Santosh", AddressId = 9, DepartmentId = 10   },
                new Employee { ID = 10, Name = "Raja", AddressId = 10, DepartmentId = 20    },
                new Employee { ID = 11, Name = "Ramesh", AddressId = 11, DepartmentId = 30  }
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
                new Address { ID = 1, AddressLine = "AddressLine1" },
                new Address { ID = 2, AddressLine = "AddressLine2" },
                new Address { ID = 3, AddressLine = "AddressLine3" },
                new Address { ID = 4, AddressLine = "AddressLine4" },
                new Address { ID = 5, AddressLine = "AddressLine5" },
                new Address { ID = 9, AddressLine = "AddressLine9" },
                new Address { ID = 10, AddressLine = "AddressLine10"},
                new Address { ID = 11, AddressLine = "AddressLine11"},
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
                new Department { ID = 10, Name = "IT"       },
                new Department { ID = 20, Name = "HR"       },
                new Department { ID = 30, Name = "Payroll"  },
            };
        }
    }

    class EmployeeResult
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string AddressLine { get; set; }
    }
}