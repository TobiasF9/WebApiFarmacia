using Model.Models;
using Models.DTO;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISellsService
    {
        List<SellsDTO> GetSellsList();
        SellsDTO GetSellById(int idOfMedicine, int idOfUser);
        SellsDTO CreateSell(SellsViewModel sell);
        List<SellsDTO> ModifySell(int id, SellsViewModel sell);
        SellsDTO RemoveSell(int id);
    }
}
