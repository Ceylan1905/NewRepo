﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string ModulName { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employees { get; set; }
    }
}
