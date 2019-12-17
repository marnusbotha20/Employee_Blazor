using Employee_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.DataAccess
{
    public class EmployeeDataAccessLayer
    {
        EmployeeContext db = new EmployeeContext();

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee Get(long id)
        {
            return db.Employees
                  .FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee entity)
        {
            db.Employees.Add(entity);
            db.SaveChanges();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.PhoneNumber = entity.PhoneNumber;

            db.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
