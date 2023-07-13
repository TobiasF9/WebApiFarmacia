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
        List<SellsDTO> GetSellById(int id);
        SellsDTO CreateSell(SellsViewModel sell);
        SellsDTO ModifySell(SellsViewModel sell);
        List<SellsDTO> RemoveSell(int id);
    }
}
