using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SellsDTO
    {
        public int IdMedicine { get; set; }
        public int IdUser { get; set; }
        public decimal? Amount { get; set; }
    }
}
