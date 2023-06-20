using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class SellsViewModel
    {
        public int Id { get; set; }
        public int IdMedicine { get; set; }
        public int IdUser { get; set; }
        public DateTime SellDate { get; set; }
        public decimal Amount { get; set; }
    }
}
