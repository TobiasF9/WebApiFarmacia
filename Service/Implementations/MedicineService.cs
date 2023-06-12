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
            var medicine = _context.Medicines.ToList();
            var medicinesList = new List<MedicineDTO>();

            foreach (var x in medicine)
            {
                medicinesList.Add(new MedicineDTO()
                {
                    IdMedicine = x.IdMedicine,
                    Name = x.Name,
                    Price = x.Price,
                    Manufacturer = x.Manufacturer
                });
            }

            medicinesList.Add(product);
            return product;
        }
        public List<MedicineDTO> ModifyMedicine(int id, MedicineDTO product)
        {
            var medicine = _context.Medicines.ToList();
            var medicinesList = new List<MedicineDTO>();

            foreach (var x in medicine)
            {
                medicinesList.Add(new MedicineDTO()
                {
                    IdMedicine = x.IdMedicine,
                    Name = x.Name,
                    Price = x.Price,
                    Manufacturer = x.Manufacturer
                });
            }

            var medicineToModify = medicinesList.Where(x => x.IdMedicine == id).First();
            medicineToModify.IdMedicine = product.IdMedicine;
            medicineToModify.Name = product.Name;
            medicineToModify.Price = product.Price;
            medicineToModify.Manufacturer = product.Manufacturer;

            return medicinesList;
        }
        public List<MedicineDTO> RemoveMedicine(int id)
        {
            var medicine = _context.Medicines.ToList();
            var medicinesList = new List<MedicineDTO>();

            foreach (var x in medicine)
            {
                medicinesList.Add(new MedicineDTO()
                {
                    IdMedicine = x.IdMedicine,
                    Name = x.Name,
                    Price = x.Price,
                    Manufacturer = x.Manufacturer
                });
            }

            var medicineToDelete = medicinesList.Where(x => x.IdMedicine == id).First();
            medicinesList.Remove(medicineToDelete);

            return medicinesList;
        }
    }
}
