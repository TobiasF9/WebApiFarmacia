using Model.Models;
using Models.DTO;
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
        SellsDTO GetSellsById(int id);
        SellsDTO CreateSell(SellsDTO sell);
        List<Sells> ModifySell(int id, SellsDTO sell);
        Sells RemoveSell(int id);
    }
}
