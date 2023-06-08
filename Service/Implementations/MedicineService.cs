using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MedicineService : IMedicineService
    {
        static List<MedicineDTO> medicinesList = new List<MedicineDTO>();
        public List<MedicineDTO> GetMedicineList()
        {          
            return medicinesList;
        }
        public MedicineDTO GetMedicineById(int id)
        {
            MedicineDTO medicine = medicinesList.Where(x => x.IdMedicine == id).First();
            return medicine;
        }
        public MedicineDTO CreateMedicine(MedicineDTO product)
        {
            var medicinesList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                medicinesList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            medicinesList.Add(product);

            return product;
        }
        public List<MedicineDTO> ModifyMedicine(int id, MedicineDTO producto)
        {
            var medicinesList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                medicinesList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            var productToModify = medicinesList.Where(x => x.IdMedicine == id).First();
            productToModify.IdMedicine = producto.IdMedicine;
            productToModify.Name = producto.Name;
            productToModify.Price = producto.Price;
            productToModify.Manufacturer = producto.Manufacturer;

            return medicinesList;
        }
        public List<MedicineDTO> RemoveMedicine(int id)
        {
            var medicinesList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                medicinesList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            var productToDelete = medicinesList.Where(x => x.IdMedicine == id).First();
            medicinesList.Remove(productToDelete);

            return medicinesList;
        }
    }
}
