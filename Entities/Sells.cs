
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etities
{
    public class Sells
    {
        //foreign key venga de medicine y de customer
        
        public int IdMedicine { get; set; }
        public int IdCustomer { get; set; }
        public float Amount { get; set; }
    }
}
