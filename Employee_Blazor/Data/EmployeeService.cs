using Employee_Blazor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.DataAccess
{
    public class EmployeeService
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        public Task<List<Employee>> GetEmployeeList()
        {
            IEnumerable<Employee> employees = objemployee.GetAllEmployees();

            var list = employees.Select(index => new Employee
            {
                DateOfBirth = index.DateOfBirth,
                Email = index.Email,
                EmployeeId = index.EmployeeId,
                FirstName = index.FirstName,
                LastName = index.LastName,
                PhoneNumber = index.PhoneNumber,
                City = index.City,
                Department = index.Department,
                Gender = index.Gender
            }).ToList();

            return Task.FromResult(list.ToList());
        }
        public void Create(Employee employee)
        {
            objemployee.AddEmployee(employee);
        }
        public Task<Employee> Details(int id)
        {
            return Task.FromResult(objemployee.GetEmployeeData(id));
        }
        public void Edit(Employee employee)
        {
            objemployee.UpdateEmployee(employee);
        }
        public void Delete(int id)
        {
            objemployee.DeleteEmployee(id);
        }
        public Task<List<Cities>> GetCities()
        {
            return Task.FromResult(objemployee.GetCityData());
        }

        public Task<List<Courses>> GetCourses()
        {
            return Task.FromResult(objemployee.GetCourses());
        }
    }
}
