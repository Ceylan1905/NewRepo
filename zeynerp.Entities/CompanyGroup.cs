﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeynerp.Entities
{
    public class CompanyGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Active Confirmation { get; set; }
    }
    public enum Active
    {
        Pasif,
        Aktif
    }

}
