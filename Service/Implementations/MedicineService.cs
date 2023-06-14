using Model.Models;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MedicineService : IMedicineService
    {
        private readonly MedicinesAPIContext _context;

        public MedicineService(MedicinesAPIContext context)
        {
            _context = context;
        }
        public List<MedicineDTO> GetMedicineList()
        {
            var medicine = _context.Medicines.ToList();
            var response = new List<MedicineDTO>();

            foreach (var x in medicine)
            {
                response.Add(new MedicineDTO()
                {
                    IdMedicine = x.IdMedicine,
                    Name = x.Name,
                    Price = x.Price,
                    Manufacturer = x.Manufacturer
                });
            }

            return response;
            //otra posibilidad, lo que no se es si hace falta el ToList();
            //return _context.Medicines.ToList();
        }
        public MedicineDTO GetMedicineById(int id)
        {
            var medicine = _context.Medicines.ToList().Where(x => x.IdMedicine == id).First();
            //usamos un inicializador de objeto
            var response = new MedicineDTO()
            {
                IdMedicine = medicine.IdMedicine,
                Name = medicine.Name,
                Price = medicine.Price,
                Manufacturer = medicine.Manufacturer
            };
            return response;
        }
        public MedicineDTO CreateMedicine(MedicineDTO product)
        {
            _context.Medicines.Add(new Medicines() 
            {
                //IdMedicine = product.IdMedicine,
                Name = product.Name,
                Price = product.Price,
                Manufacturer = product.Manufacturer
            });
            _context.SaveChanges();
            return product;
        }
        //no se si conviene devolver una lista de Medicines o una lista de MedicineDTO
        //no se si conviene modificar directamente la tabla (con _context.Medicines) o si es mejor, crear una variable y asignarle _context.Medicines
        public List<Medicines> ModifyMedicine(int id, MedicineDTO product)
        {
            //var medicineToModify = _context.Medicines.ToList().Where(x => x.IdMedicine == id).First();
            _context.Medicines.ToList().Where(x => x.IdMedicine == id).First().IdMedicine = product.IdMedicine;
            _context.Medicines.ToList().Where(x => x.IdMedicine == id).First().Name = product.Name;
            _context.Medicines.ToList().Where(x => x.IdMedicine == id).First().Price = product.Price;
            _context.Medicines.ToList().Where(x => x.IdMedicine == id).First().Manufacturer = product.Manufacturer;

            _context.SaveChanges();
            return _context.Medicines.ToList();
        }
        public Medicines RemoveMedicine(int id)
        {
            var medicineToDelete = _context.Medicines.ToList().Where(x => x.IdMedicine == id).First();
            _context.Medicines.Remove(medicineToDelete); //no entiendo esto. no entiendo xq aca no hay que hacer el .ToList()

            _context.SaveChanges();
            return medicineToDelete;
        }
    }
}
