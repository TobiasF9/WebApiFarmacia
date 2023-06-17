using Model.Models;
using Models.DTO;
using Models.ViewModel;
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
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Manufacturer = x.Manufacturer
                });
            }

            return response;
        }
        public MedicineDTO GetMedicineById(int id)
        {
            var medicine = _context.Medicines.ToList().Where(x => x.Id == id).First();
            //usamos un inicializador de objeto
            var response = new MedicineDTO()
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Price = medicine.Price,
                Manufacturer = medicine.Manufacturer
            };
            return response;
        }
        public MedicineDTO CreateMedicine(MedicineViewModel product)
        {
            _context.Medicines.Add(new Medicines() 
            {
                //Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Manufacturer = product.Manufacturer
            });
            _context.SaveChanges();
            var response = new MedicineDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Manufacturer = product.Manufacturer
            };

            return response;
        }
        //no se si conviene devolver una lista de Medicines o una lista de MedicineDTO
        //no se si conviene modificar directamente la tabla (con _context.Medicines) o si es mejor, crear una variable y asignarle _context.Medicines
        public List<MedicineDTO> ModifyMedicine(int id, MedicineViewModel product)
        {
            //var medicineToModify = _context.Medicines.ToList().Where(x => x.Id == id).First();
            _context.Medicines.ToList().Where(x => x.Id == id).First().Id = product.Id;
            _context.Medicines.ToList().Where(x => x.Id == id).First().Name = product.Name;
            _context.Medicines.ToList().Where(x => x.Id == id).First().Price = product.Price;
            _context.Medicines.ToList().Where(x => x.Id == id).First().Manufacturer = product.Manufacturer;

            _context.SaveChanges();
            var response = new List<MedicineDTO>();

            foreach (var x in _context.Medicines)
            {
                response.Add(new MedicineDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Manufacturer = x.Manufacturer
                });
            }
            return response;
        }
        public MedicineDTO RemoveMedicine(int id)
        {
            var medicineToDelete = _context.Medicines.ToList().Where(x => x.Id == id).First();
            _context.Medicines.Remove(medicineToDelete); //no entiendo esto. no entiendo xq aca no hay que hacer el .ToList()

            _context.SaveChanges();
            var response = new MedicineDTO
            {
                Id = medicineToDelete.Id,
                Name = medicineToDelete.Name,
                Price = medicineToDelete.Price,
                Manufacturer = medicineToDelete.Manufacturer
            };
            return response;
        }
    }
}
