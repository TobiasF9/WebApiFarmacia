﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class MedicineDTO
    {
        public int IdMedicine { get; set; }
        public string Name { get; set; } = string.Empty;
        //public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
    }
}
