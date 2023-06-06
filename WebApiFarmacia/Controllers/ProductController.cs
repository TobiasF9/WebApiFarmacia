using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Modelo.DTO;
using System.Collections.Generic;
using Services.Implementations;

namespace WebApiFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService = new ProductService();

        public ProductController()
        {

        }

        [HttpGet("GetProductsList")]
        public ActionResult<List<ProductDTO>> GetProductsList()
        {
            var response = _productService.GetProductsList();
            return Ok(response);
        }

        [HttpGet("GetProductoById/{id}")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            var response = _productService.GetProductoById(id);

            return Ok(response);
        }

        [HttpPost("PostProducto")]
        public ActionResult<ProductDTO> CreateProduct([FromBody] ProductDTO product)
        {
            var response = _productService.CreateProduct(product);

            return Ok(response);
        }
        
        [HttpPut("PutProducto/{id}")]
        public ActionResult<ProductDTO> ModifyProduct(int id, [FromBody] ProductDTO product)
        {
            var response = _productService.ModifyProduct(id, product);

            return Ok(response);
        }
        [HttpDelete("DeleteProducto/{id}")]
        public ActionResult<ProductDTO> DeleteProduct(int id)
        {
            var response = _productService.RemoveProduct(id);

            return Ok(response);
        }
    }
}
