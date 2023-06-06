using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.DTO;
using Models.DTO;
using Services.Implementations;

namespace WebApiFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly SellerService _sellerService = new SellerService();

        [HttpGet("GetSellerList")]
        public ActionResult<List<SellerDTO>> GetSellerList()
        {
            var response = _sellerService.GetSellerList();
            return Ok(response);
        }

        [HttpGet("GetSellerId/{id}")]
        public ActionResult<SellerDTO> GetSellerById(int id)
        {
            var response = _sellerService.GetSellerById(id);

            return Ok(response);
        }

        [HttpPost("PostSeller")]
        public ActionResult<SellerDTO> CreateSeller([FromBody] SellerDTO seller)
        {
            var response = _sellerService.CreateSeller(seller);

            return Ok(response);
        }
        //el put es necesario?
        [HttpPut("PutSeller/{id}")]
        public ActionResult<SellerDTO> ModifySeller(int id, [FromBody] SellerDTO seller)
        {

            var response = _sellerService.ModifySeller(id, seller);

            return Ok(response);
        }

        [HttpDelete("DeleteSeller/{id}")]
        public ActionResult<SellerDTO> DeleteSeller(int id)
        {
            var response = _sellerService.RemoveSeller(id);

            return Ok(response);
        }
    }
}
