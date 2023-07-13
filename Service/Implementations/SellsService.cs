using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class SellsService : ISellsService
    {
        private readonly MedicinesAPIContext _context;
        private readonly IMapper _mapper;

        public SellsService(MedicinesAPIContext context)
        {
            _context = context;
            _mapper = AutoMapperConfig.Configure();
        }

        public List<SellsDTO> GetSellsList()
        {

            List<SellsDTO> responseList = (from sell in _context.Sells
                                           join medicine in _context.Medicines
                                           on sell.IdMedicine equals medicine.Id
                                           join user in _context.Users
                                           on sell.IdUser equals user.Id
                                           select new SellsDTO()
                                           {
                                               Id = sell.Id,
                                               //IdMedicine = medicine.Id,
                                               MedicineName = medicine.Name,
                                               //IdUser = user.Id,
                                               UserName = user.Name,
                                               SellDate = sell.SellDate,
                                               Amount = sell.Amount
                                           }
                                           ).ToList();

            return responseList;
        }

        public List<SellsDTO> GetSellById(int id)
        {
            List<SellsDTO> responseList = (from sell in _context.Sells
                                           join medicine in _context.Medicines
                                           on sell.IdMedicine equals medicine.Id
                                           join user in _context.Users
                                           on sell.IdUser equals user.Id
                                           select new SellsDTO()
                                           {
                                               Id = sell.Id,
                                               //IdMedicine = medicine.Id,
                                               MedicineName = medicine.Name,
                                               //IdUser = user.Id,
                                               UserName = user.Name,
                                               SellDate = sell.SellDate,
                                               Amount = sell.Amount
                                           }
                                       ).ToList();

            List<SellsDTO> response = responseList.Where(s => s.Id == id).ToList();
            return response;
        }

        public SellsDTO CreateSell(SellsViewModel sell)
        {
            
            _context.Sells.Add(new Sells()
            {
                Id = sell.Id,
                IdMedicine = sell.IdMedicine,
                IdUser = sell.IdUser,
                SellDate = sell.SellDate,
                Amount = sell.Amount
            });
            _context.SaveChanges();

            var lastSell = _context.Sells
    .Include(s => s.IdMedicineNavigation) // Cargar la propiedad de navegación del medicamento
    .Include(s => s.IdUserNavigation) // Cargar la propiedad de navegación del usuario
    .OrderBy(x => x.Id)
    .LastOrDefault();
            var response = (new SellsDTO()
            {
                Id = lastSell.Id,
                MedicineName = lastSell.IdMedicineNavigation.Name,
                UserName = lastSell.IdUserNavigation.Name,
                SellDate = lastSell.SellDate,
                Amount = lastSell.Amount
            });
            return response;
        }

        public SellsDTO ModifySell(SellsViewModel sell)
        {
            //Sells sellToModify = _context.Sells.Where(s => s.Id == sell.Id).Where(s => s.IdMedicine == sell.IdMedicine).Where(s => s.IdUser == sell.IdUser).First();
            //sellToModify.Id = sell.Id;
            //sellToModify.IdMedicine = sell.IdMedicine;
            //sellToModify.IdUser = sell.IdUser;
            //sellToModify.SellDate = sell.SellDate;
            //sellToModify.Amount = sell.Amount;

            Sells sellToModify = _context.Sells
    .Include(s => s.IdMedicineNavigation) // Cargar la propiedad de navegación del medicamento
    .Include(s => s.IdUserNavigation) // Cargar la propiedad de navegación del usuario
    .Where(s => s.Id == sell.Id)
    .Where(s => s.IdMedicine == sell.IdMedicine)
    .Where(s => s.IdUser == sell.IdUser)
    .First();
            sellToModify.Id = sell.Id;
            sellToModify.IdMedicine = sell.IdMedicine;
            sellToModify.IdUser = sell.IdUser;
            sellToModify.SellDate = sell.SellDate;
            sellToModify.Amount = sell.Amount;

            _context.SaveChanges();
                var response = (new SellsDTO()
                {
                    Id = sellToModify.Id,
                    MedicineName = sellToModify.IdMedicineNavigation.Name,
                    UserName = sellToModify.IdUserNavigation.Name,
                    SellDate = sellToModify.SellDate,
                    Amount = sellToModify.Amount
                });
            return response;
        }

        public List<SellsDTO> RemoveSell(int id)
        {
            var SellsToDelete = _context.Sells.ToList().Where(x => x.Id == id);
            //var response = _mapper.Map<SellsDTO>(SellsToDelete);
            List<SellsDTO> responseList = (from sell in _context.Sells
                                           join medicine in _context.Medicines
                                           on sell.IdMedicine equals medicine.Id
                                           join user in _context.Users
                                           on sell.IdUser equals user.Id
                                           select new SellsDTO()
                                           {
                                               Id = sell.Id,
                                               //IdMedicine = medicine.Id,
                                               MedicineName = medicine.Name,
                                               //IdUser = user.Id,
                                               UserName = user.Name,
                                               SellDate = sell.SellDate,
                                               Amount = sell.Amount
                                           }
                                       ).ToList();

            List<SellsDTO> response = responseList.Where(s => s.Id == id).ToList();
            //List<SellsDTO> response = SellsToDelete.Where(s => s.Id == id).ToList();
            foreach (var item in SellsToDelete)
            {
                _context.Sells.Remove(item);
            }
            //_context.Sells.Remove(SellsToDelete);
            _context.SaveChanges();

            

            return response;
            
        }
        
    }
}
