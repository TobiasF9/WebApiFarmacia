﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SellerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float? Balance { get; set; }
    }
}