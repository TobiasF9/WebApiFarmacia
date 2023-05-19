using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Customer
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public int DNI { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string PaymentMethods { get; set; }

        public void ChooseProducts()
        {

        }
        public void PayWithMedicalPrescription()
        {

        }

        public void PayWithoutMedicalPrescription()
        {

        }

        public void PayAccordingToPaymentMethod() { 
        }


    }
}
