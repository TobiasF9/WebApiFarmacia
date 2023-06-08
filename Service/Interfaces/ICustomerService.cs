using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        List<MedicineDTO> GetCustomerList();
        MedicineDTO GetCustomerById(int id);
        MedicineDTO CreateCustomer(MedicineDTO product);
        List<MedicineDTO> ModifyCustomer(int id, MedicineDTO producto);
        List<MedicineDTO> RemoveCustomer(int id);
    }
}
