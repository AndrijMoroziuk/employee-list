﻿using EmployeeList.Domain.Entities.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Domain.Entities.Models
{
    public class TestModel : BaseEntity
    {
        public string First { get; set; }
        public int Second { get; set; }
    }
}
