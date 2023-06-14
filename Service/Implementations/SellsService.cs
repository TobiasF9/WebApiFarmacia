using Model.Models;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.Implementations
{
    public class SellsService //ISellsService
    {
        private readonly MedicinesAPIContext _context;

        public SellsService(MedicinesAPIContext context)
        {
            _context = context;
        }

        //public SellsDTO CreateSell(SellsDTO sell)
        //{
        //    var medicine = _context.Sells.ToList();
        //    var response = new List<SellsDTO>();

        //    foreach (var x in medicine)
        //    {
        //        response.Add(new SellsDTO()
        //        {
        //            IdMedicine = x.IdMedicine,
        //            IdUser = x.IdUser,
        //            Amount = x.Amount
        //        });
        //    }

        //    return response;
        //}

        //public SellsDTO GetMedicineById(int id)
        //{
        //    var medicine = _context.Medicines.ToList().Where(x => x.IdMedicine == id).First();
        //    //usamos un inicializador de objeto
        //    var response = new MedicineDTO()
        //    {
        //        IdMedicine = medicine.IdMedicine,
        //        Name = medicine.Name,
        //        Price = medicine.Price,
        //        Manufacturer = medicine.Manufacturer
        //    };
        //    return response;
        //}

        public SellsDTO CreateSell(SellsDTO sell)
        {
            _context.Sells.Add(new Sells()
        {
                IdMedicine = sell.IdMedicine,
                IdUser = sell.IdUser,
                Amount = sell.Amount
            });
            _context.SaveChanges();
            return sell;
        }
        public List<SellsDTO> GetMedicineList()
        {
            throw new NotImplementedException();
        }

        public List<Sells> ModifyMedicine(int id, SellsDTO sell)
        {
            throw new NotImplementedException();
        }

        public Sells RemoveMedicine(int id)
        {
            throw new NotImplementedException();
        }
    }
}
