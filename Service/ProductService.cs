using Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService
    {
        public List<ProductDTO> GetProductsList()
        {
            var productsList = new List<ProductDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new ProductDTO()
                {
                    IdProduct = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }
            return productsList;

        }
        public ProductDTO GetProductoById(int id)
        {
            var productsList = new List<ProductDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new ProductDTO()
                {
                    IdProduct = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            ProductDTO product = productsList.Where(x => x.IdProduct == id).First();

            return product;
        }
        public ProductDTO CreateProduct(ProductDTO product)
        {
            var productsList = new List<ProductDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new ProductDTO()
                {
                    IdProduct = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            productsList.Add(product);

            return product;
        }
        public List<ProductDTO> ModifyProduct(int id, ProductDTO producto)
        {
            var productsList = new List<ProductDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new ProductDTO()
                {
                    IdProduct = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            var productToModify = productsList.Where(x => x.IdProduct == id).First();
            productToModify.IdProduct = producto.IdProduct;
            productToModify.Name = producto.Name;
            productToModify.Price = producto.Price;
            productToModify.Manufacturer = producto.Manufacturer;

            return productsList;
        }
        public List<ProductDTO> RemoveProduct(int id)
        {
            var productsList = new List<ProductDTO>();

            for (int i = 0; i < 4; i++)
            {
                productsList.Add(new ProductDTO()
                {
                    IdProduct = i,
                    Name = "Aspirina",
                    Price = 2500,
                    Manufacturer = "Bayer"
                });
            }

            var productToDelete = productsList.Where(x => x.IdProduct == id).First();
            productsList.Remove(productToDelete);

            return productsList;
        }
    }
}
