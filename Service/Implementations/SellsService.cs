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
            //var sells = _context.Sells.ToList();
            //var response = new List<SellsDTO>();

            //foreach (var x in sells)
            //{
            //    response.Add(new SellsDTO()
            //    {
            //        Id = x.Id,
            //        IdMedicine = x.IdMedicine,
            //        IdUser = x.IdUser,
            //        SellDate = x.SellDate,
            //        Amount = x.Amount
            //    });
            //}
            //return response;

            //List<SellsDTO> responseList = (from sell in _context.Sells
            //                               join medicine in _context.Medicines
            //                               on sell.IdMedicine equals medicine.Id
            //                               join user in _context.Users
            //                               on sell.IdUser equals user.Id
            //                               select new SellsDTO()
            //                               {
            //                                   Id = sell.Id,
            //                                   //IdMedicine = medicine.Id,
            //                                   MedicineName = medicine.Name,
            //                                   //IdUser = user.Id,
            //                                   UserName = user.Name,
            //                                   SellDate = sell.SellDate,
            //                                   Amount = sell.Amount
            //                               }
            //                               ).ToList();

            //return responseList;
            return _mapper.Map<List<SellsDTO>>(_context.Sells.ToList());
        }

        public SellsDTO GetSellById(int id)
        {
            //cuando se usa toda esta funcion y cuando no?
            //List<SellsDTO> responseList = (from sell in _context.Sells
            //                           join medicine in _context.Medicines
            //                           on sell.IdMedicine equals medicine.Id
            //                           join user in _context.Users
            //                           on sell.IdUser equals user.Id
            //                           select new SellsDTO()
            //                           {
            //                               Id = sell.Id,
            //                               //IdMedicine = medicine.Id,
            //                               MedicineName = medicine.Name,
            //                               //IdUser = user.Id,
            //                               UserName = user.Name,
            //                               SellDate = sell.SellDate,
            //                               Amount = sell.Amount
            //                           }
            //                           ).ToList();

            //SellsDTO response = responseList.First(s => s.Id == id);
            //return response;
            return _mapper.Map<SellsDTO>(_context.Sells.Where(x => x.Id == id).First());
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
            //_context.Sells.ToList().Where(x => x.Id == id).First().Id = sell.Id;
            //_context.Sells.ToList().Where(x => x.Id == id).First().IdMedicine = sell.IdMedicine;
            //_context.Sells.ToList().Where(x => x.Id == id).First().IdUser = sell.IdUser;
            //_context.Sells.ToList().Where(x => x.Id == id).First().SellDate = sell.SellDate;
            //_context.Sells.ToList().Where(x => x.Id == id).First().Amount = sell.Amount;

            //_context.SaveChanges();
            //var response = new List<SellsDTO>();

            //foreach (var x in _context.Sells)
            //{
            //    response.Add(new SellsDTO()
            //    {
            //        Id = x.Id,
            //        IdMedicine = x.IdMedicine,
            //        IdUser = x.IdUser,
            //        SellDate = x.SellDate,
            //        Amount = x.Amount
            //    });
            //}
            //return response;
            Sells sellToModify = _context.Sells.Single(s => s.Id == sell.Id);
            //sellToModify.Id = sell.Id;
            sellToModify.IdMedicine = sell.IdMedicine;
            sellToModify.IdUser = sell.IdUser;
            sellToModify.SellDate = sell.SellDate;
            sellToModify.Amount = sell.Amount;

            _context.SaveChanges();
            var sellModfied = _context.Sells.FirstOrDefault(x => x.Id == sell.Id);

            return _mapper.Map<SellsDTO>(sellModfied);
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
