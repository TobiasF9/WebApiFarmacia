using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SellsDTO
    {
        public int Id { get; set; }
        //public int IdMedicine { get; set; }
        public string MedicineName { get; set; } = string.Empty;    
        //public int IdUser { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime SellDate { get; set; }
        public decimal? Amount { get; set; }
    }
}
