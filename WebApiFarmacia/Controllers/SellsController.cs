using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Models.DTO;
using Services.Interfaces;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly ISellsService _sellsService;

        public SellsController(ISellsService medicineService)
        {
            _sellsService = medicineService;
        }

        [HttpGet("GetSellsList")]
        public ActionResult<List<SellsDTO>> GetMedicineList()
        {
            var response = _sellsService.GetMedicineList();
            return Ok(response);
        }

        [HttpGet("GetSellsById/{id}")]
        public ActionResult<SellsDTO> GetMedicineById(int id)
        {
            var response = _sellsService.GetMedicineById(id);

            return Ok(response);
        }

        [HttpPost("PostSells")]
        //public ActionResult<SellsDTO> CreateSell([FromBody] SellsDTO sell)
        //{
        //    var response = _sellsService.CreateSell(sell);

        //    return Ok(response);
        //}

        [HttpPut("PutSells/{id}")]
        public ActionResult<Sells> ModifyMedicine(int id, [FromBody] SellsDTO sell)
        {
            var response = _sellsService.ModifyMedicine(id, sell);

            return Ok(response);
        }
        [HttpDelete("DeleteSells/{id}")]
        public ActionResult<Sells> RemoveMedicine(int id)
        {
            var response = _sellsService.RemoveMedicine(id);

            return Ok(response);
        }
    }
}
