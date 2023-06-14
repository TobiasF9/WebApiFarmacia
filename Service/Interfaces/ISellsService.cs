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
        List<SellsDTO> GetMedicineList();
        SellsDTO GetMedicineById(int id);
        SellsDTO CreateMedicine(SellsDTO sell);
        List<Sells> ModifyMedicine(int id, SellsDTO sell);
        Sells RemoveMedicine(int id);
    }
}
