﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public int? DNI { get; set; }
        //public float Balance { get; set; }
        public int IdRole { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
