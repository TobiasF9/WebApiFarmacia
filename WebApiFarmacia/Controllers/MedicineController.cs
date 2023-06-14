using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models.DTO;
using System.Collections.Generic;
using Services.Implementations;
using Services.Interfaces;
using Model.Models;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet("GetMedicineList")]
        public ActionResult<List<MedicineDTO>> GetMedicineList()
        {
            var response = _medicineService.GetMedicineList();
            return Ok(response);
        }

        [HttpGet("GetMedicineById/{id}")]
        public ActionResult<MedicineDTO> GetMedicineById(int id)
        {
            var response = _medicineService.GetMedicineById(id);

            return Ok(response);
        }

        [HttpPost("PostMedicine")]
        public ActionResult<MedicineDTO> CreateMedicine([FromBody] MedicineDTO product)
        {
            var response = _medicineService.CreateMedicine(product);

            return Ok(response);
        }
        
        [HttpPut("PutMedicine/{id}")]
        public ActionResult<Medicines> ModifyMedicine(int id, [FromBody] MedicineDTO product)
        {
            var response = _medicineService.ModifyMedicine(id, product);

            return Ok(response);
        }
        [HttpDelete("DeleteMedicine/{id}")]
        public ActionResult<Medicines> RemoveMedicine(int id)
        {
            var response = _medicineService.RemoveMedicine(id);

            return Ok(response);
        }
    }
}
