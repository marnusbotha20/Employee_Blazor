using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
