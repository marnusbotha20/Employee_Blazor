using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee_Blazor.Models
{
    public partial class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
