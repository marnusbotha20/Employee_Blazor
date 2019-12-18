﻿using Employee_Blazor.DataAccess;
using Employee_Blazor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.Service
{
    public class EmployeeService
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        public Task<List<Employee>> GetEmployeeList()
        {
            IEnumerable<Employee> employees = objemployee.GetAllEmployees();
            return Task.FromResult(employees.ToList());
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
