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
        List<MedicineDTO> ModifyMedicine(int id, MedicineDTO producto);
        List<MedicineDTO> RemoveMedicine(int id);

    }
}
