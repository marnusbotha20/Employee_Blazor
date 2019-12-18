using Employee_Blazor.DataAccess;
using Employee_Blazor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.Service
{
    public class CourseService
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        public Task<List<Courses>> GetCourses()
        {
            IEnumerable<Courses> courses = objemployee.GetCourses();
            return Task.FromResult(courses.ToList());
        }

        public Task<Courses> CourseDetails(int id)
        {
            return Task.FromResult(objemployee.GetCoursesDetails(id));
        }

        public void EditCourse(Courses courses)
        {
            objemployee.UpdateCourse(courses);
        }

        public void DeleteCourse(int id)
        {
            objemployee.DeleteCourse(id);
        }

        public void CreateCourse(Courses courses)
        {
            objemployee.AddCourse(courses);
        }
    }
}
