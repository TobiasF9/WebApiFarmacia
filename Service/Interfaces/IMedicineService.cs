using Model.Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMedicineService
    {
        List<MedicineDTO> GetMedicineList();
        MedicineDTO GetMedicineById(int id);
        MedicineDTO CreateMedicine(MedicineDTO product);
        List<Medicines> ModifyMedicine(int id, MedicineDTO product);
        Medicines RemoveMedicine(int id);

    }
}
