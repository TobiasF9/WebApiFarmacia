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

        public SellsDTO GetSellById(int id)
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

            SellsDTO response = responseList.First(s => s.Id == id);
            return response;
        }

        public SellsDTO CreateSell(SellsViewModel sell)
        {
            
            _context.Sells.Add(new Sells()
            {
                IdMedicine = sell.IdMedicine,
                IdUser = sell.IdUser,
                SellDate = sell.SellDate,
                Amount = sell.Amount
            });
            _context.SaveChanges();

            var lastMedicine = _context.Medicines.OrderBy(x => x.Id).Last();
            return _mapper.Map<SellsDTO>(lastMedicine);
        }

        public SellsDTO ModifySell(SellsViewModel sell)
        {
            Sells sellToModify = _context.Sells.Single(s => s.Id == sell.Id);
            sellToModify.Id = sell.Id;
            sellToModify.IdMedicine = sell.IdMedicine;
            sellToModify.IdUser = sell.IdUser;
            sellToModify.SellDate = sell.SellDate;
            sellToModify.Amount = sell.Amount;

            _context.SaveChanges();
                var response = (new SellsDTO()
                {
                    Id = sellToModify.Id,
                    IdMedicine = sellToModify.IdMedicine,
                    IdUser = sellToModify.IdUser,
                    SellDate = sellToModify.SellDate,
                    Amount = sellToModify.Amount
                });
            return response;
        }

        public SellsDTO RemoveSell(int id)
        {
            var SellsToDelete = _context.Sells.ToList().Where(x => x.Id == id).First();
            var response = _mapper.Map<SellsDTO>(SellsToDelete);
            _context.Sells.Remove(SellsToDelete);
            _context.SaveChanges();

            return response;
        }
    }
}
