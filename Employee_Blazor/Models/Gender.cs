﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Blazor.Models
{
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female
    }
}
