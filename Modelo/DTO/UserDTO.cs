using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? DNI { get; set; }
        public float Balance { get; set; }
    }
}
