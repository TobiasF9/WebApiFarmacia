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
    public class SellsService : ISellsService
    {
        private readonly MedicinesAPIContext _context;

        public SellsService(MedicinesAPIContext context)
        {
            _context = context;
        }

        public List<SellsDTO> GetSellsList()
        {
            var sells = _context.Sells.ToList();
            var response = new List<SellsDTO>();

            foreach (var x in sells)
            {
                response.Add(new SellsDTO()
                {
                    IdMedicine = x.IdMedicine,
                    IdUser = x.IdUser,
                    Amount = x.Amount
                });
            }
            return response;
        }

        public SellsDTO GetSellById(int idOfMedicine, int idOfUser)
        {
            //a que id llamas aca? tenemos que hacer todo el quilombo de consultas y manejes de de sql q hace el profe en getlistado organizacion service
            //var user = _context.User.ToList().Where(x => x.IdMedicine == id).First();

                                        //cuando se usa toda esta funcion y cuando no?
            List<SellsDTO> responseList = (from sell in _context.Sells
                                       join medicine in _context.Medicines
                                       on sell.IdMedicine equals medicine.IdMedicine
                                       join user in _context.User
                                       on sell.IdUser equals user.Id
                                       select new SellsDTO()
                                       {
                                           IdMedicine = medicine.IdMedicine,
                                           IdUser = user.Id,
                                           Amount = sell.Amount
                                       }
                                       ).ToList();

            SellsDTO response = responseList.First(s => s.IdMedicine == idOfMedicine && s.IdUser == idOfUser);
            //.Where(x => x.IdMedicine == id)
            //.First();
            //var response = new SellsDTO()
            //{
            //    IdMedicine = user.IdMedicine,
            //    IdUser = user.IdUser,
            //    Amount = user.Amount
            //};

            return response;
        }

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

        public List<Sells> ModifySell(int id, SellsDTO sell)
        {
            throw new NotImplementedException();
        }

        public Sells RemoveSell(int id)
        {
            throw new NotImplementedException();
        }
    }
}
