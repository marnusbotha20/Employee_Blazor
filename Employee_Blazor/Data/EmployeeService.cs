using Employee_Blazor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.DataAccess
{
    public class EmployeeService
    {
        EmployeeDataAccessLayer DataRepository = new EmployeeDataAccessLayer();
        public Task<List<Employee>> GetEmployeesAsync()
        {
            IEnumerable<Employee> employees = DataRepository.GetAll();

            var list = employees.Select(index => new Employee
            {
                DateOfBirth = index.DateOfBirth,
                Email = index.Email,
                EmployeeId = index.EmployeeId,
                FirstName = index.FirstName,
                LastName = index.LastName,
                PhoneNumber = index.PhoneNumber
            }).ToList();

            return Task.FromResult(list.ToList());
        }

        public void AddEmployee(Employee model)
        {
            DataRepository.Add(model);
        }
    }
}
