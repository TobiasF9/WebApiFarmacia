using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; }

        public float DebtCollection()
        {
            return Balance;
        }
        public void AddProduct()
        {

        }
        public void RemoveProduct()
        {
        
        }

        public void UpdateProductPrice() 
        {
        
        }
    }
}
