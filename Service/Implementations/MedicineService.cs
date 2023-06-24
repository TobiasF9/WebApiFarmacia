using AutoMapper;
using Model.Models;
using Models.DTO;
using Models.ViewModel;
using Services.Interfaces;
using Services.Mappings;
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
        private readonly IMapper _mapper;

        public MedicineService(MedicinesAPIContext context)
        {
            _context = context;
            _mapper = AutoMapperConfig.Configure();
        }
        public List<MedicineDTO> GetMedicineList()
        {
            //var list = new List<MedicineDTO>();
            //return list;
            return _mapper.Map<List<MedicineDTO>>(_context.Medicines.ToList());
        }
        public MedicineDTO GetMedicineById(int id)
        {
            return _mapper.Map<MedicineDTO>(_context.Medicines.Where(x => x.Id == id).First());
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

            var lastMedicine = _context.Medicines.OrderBy(x => x.Id).Last();
            return _mapper.Map<MedicineDTO>(lastMedicine);
        }
        public MedicineDTO ModifyMedicine(MedicineViewModel product)
        {
            Medicines medicineToModify = _context.Medicines.Single(s => s.Id == product.Id);
            //medicineToModify.Id = product.Id;
            medicineToModify.Name = product.Name;
            medicineToModify.Price = product.Price;
            medicineToModify.Manufacturer = product.Manufacturer;

            _context.SaveChanges();
            var medicineModfied = _context.Medicines.FirstOrDefault(x => x.Id == product.Id);

            return _mapper.Map<MedicineDTO>(medicineModfied);
        }
        public MedicineDTO RemoveMedicine(int id)
        {
            //acá el uso del mapper, está mal?
            var medicineToDelete = _context.Medicines.ToList().Where(x => x.Id == id).First();
            var response = _mapper.Map<MedicineDTO>(medicineToDelete);
            _context.Medicines.Remove(medicineToDelete);
            _context.SaveChanges();

            return response;
        }
    }
}
