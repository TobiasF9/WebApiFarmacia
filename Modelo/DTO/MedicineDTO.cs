using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class MedicineDTO
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
    }
}
