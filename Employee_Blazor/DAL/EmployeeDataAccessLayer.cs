﻿using Employee_Blazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.DataAccess
{
    public class EmployeeDataAccessLayer
    {
        EmployeeContext db = new EmployeeContext();

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employees.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployeeData(long id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                db.Entry(employee).State = EntityState.Detached;
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddCourse(Courses courses)
        {
            try
            {
                db.Courses.Add(courses);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Cities> GetCityData()
        {
            try
            {
                return db.Cities.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Course Methods
        public List<Courses> GetCourses()
        {
            return db.Courses.ToList();
        }

        public Courses GetCoursesDetails(int id)
        {
            try
            {
                var course = db.Courses.Find(id);
                db.Entry(course).State = EntityState.Detached;
                return course;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCourse(Courses courses)
        {
            db.Entry(courses).State = EntityState.Modified;
            db.SaveChanges();
        }
        
        public void DeleteCourse(int id)
        {
            try
            {
                Courses c = db.Courses.Find(id);
                db.Courses.Remove(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
