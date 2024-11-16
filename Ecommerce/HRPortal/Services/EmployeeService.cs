using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories;
using System.Xml.Linq;

namespace HRPortal.Services
{

    public class EmployeeService : IEmployeeService
    {
        public static string filename = "D:/employees.json";
        public EmployeeService()
        {
            List<Employee> products = new List<Employee>();
            Seeding();
        }

        public bool Seeding()
        {

            bool status = false;
            List<Employee> Employees = new List<Employee>();
            //List<Credential> credentials = new List<Credential>();
            Employees.Add(new Employee { Id = 1, Name = "Diya", BasicSalary = 500000, DailyAllowance = 500, WorkingDays = 5, JoinDate = DateTime.Now, IsConfirmed = true });
            Employees.Add(new Employee { Id = 2, Name = "Shraddha", BasicSalary = 500000, DailyAllowance = 500, WorkingDays = 5, JoinDate = DateTime.Now, IsConfirmed = true });
            Employees.Add(new Employee { Id = 3, Name = "Pratiksha", BasicSalary = 500000, DailyAllowance = 500, WorkingDays = 5, JoinDate = DateTime.Now, IsConfirmed = true });
            Employees.Add(new Employee { Id = 4, Name = "Shruti", BasicSalary = 500000, DailyAllowance = 500, WorkingDays = 5, JoinDate = DateTime.Now, IsConfirmed = true });


            //IDataRepository<Employee> repository = new BinaryRepository<Employee>();
            IDataRepository<Employee> repository = new JsonRepository<Employee>();
            //IDataRepository<Credential> dataRepository = new BinaryRepository<Credential>();
            //IDataRepository<Credential> dataRepository = new JsonRepository<Credential>();
            status = repository.Serialize(filename, Employees);
            //status = false;
            //status = dataRepository.Serialize(credfile, credentials);
            return status;
        }




        public bool Register(Employee employee)
        {
            bool status = false;
            List<Employee> employees = new List<Employee>();
            employees = GetAllEmployees();
            int cnt = employees.Count;
            employee.Id = cnt + 1;
            employees.Add(employee);

            IDataRepository<Employee> repository = new JsonRepository<Employee>();

            status = repository.Serialize(filename, employees);
            return status;
        }


        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            //IDataRepository<Employee> repository = new BinaryRepository<Employee>();
            IDataRepository<Employee> repository = new JsonRepository<Employee>();

            employees = repository.Deserialize(filename);
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            Employee foundEmployee = null;
            List<Employee> Employees = GetAllEmployees();
            foreach (Employee u in Employees)
            {
                if (u.Id == id)
                {
                    foundEmployee = u;
                }
            }
            return foundEmployee;
        }


        public bool Delete(int id)
        {
            Employee employee = GetEmployee(id);
            if (employee != null)
            {
                List<Employee> employees = GetAllEmployees();
                employees = employees.FindAll((e) => e.Id != id);
                IDataRepository<Employee> repository = new JsonRepository<Employee>();
                repository.Serialize(@"D:\employees.json", employees);
                return true;
            }
            return false;
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee emp)
        {
            Employee employee = GetEmployee(emp.Id);
            if (employee != null)
            {
                List<Employee> employees = GetAllEmployees();
                employees = employees.FindAll((e) => e.Id != emp.Id);
                employees.Add(emp);
                IDataRepository<Employee> repository = new JsonRepository<Employee>();
                //IDataRepository<Product> repository = new BinaryRepository<Product>();
                //repository.Serialize("D:/products.dat", allProducts);
                repository.Serialize(filename, employees);

            }
            return true;
        }
    }
}