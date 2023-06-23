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
    public interface IMedicineService
    {
        List<MedicineDTO> GetMedicineList();
        MedicineDTO GetMedicineById(int id);
        MedicineDTO CreateMedicine(MedicineViewModel product);
        MedicineDTO ModifyMedicine(MedicineViewModel product);
        MedicineDTO RemoveMedicine(int id);

    }
}
