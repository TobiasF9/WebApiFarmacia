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
        static List<MedicineDTO> productsList = new List<MedicineDTO>();
        public List<MedicineDTO> GetMedicineList()
        {
            var productsList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }
            return productsList;

        }
        public MedicineDTO GetMedicineById(int id)
        {
            var productsList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            MedicineDTO product = productsList.Where(x => x.IdMedicine == id).First();

            return product;
        }
        public MedicineDTO CreateMedicine(MedicineDTO product)
        {
            var productsList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            productsList.Add(product);

            return product;
        }
        public List<MedicineDTO> ModifyMedicine(int id, MedicineDTO producto)
        {
            var productsList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            var productToModify = productsList.Where(x => x.IdMedicine == id).First();
            productToModify.IdMedicine = producto.IdMedicine;
            productToModify.Name = producto.Name;
            productToModify.Price = producto.Price;
            productToModify.Manufacturer = producto.Manufacturer;

            return productsList;
        }
        public List<MedicineDTO> RemoveMedicine(int id)
        {
            var productsList = new List<MedicineDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new MedicineDTO()
                {
                    IdMedicine = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            var productToDelete = productsList.Where(x => x.IdMedicine == id).First();
            productsList.Remove(productToDelete);

            return productsList;
        }
    }
}
