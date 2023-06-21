using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models.DTO;
using System.Collections.Generic;
using Services.Implementations;
using Services.Interfaces;
using Model.Models;
using Models.ViewModel;

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

        [HttpGet("GetAll")]
        public ActionResult<List<MedicineDTO>> GetMedicineList()
        {
            var response = _medicineService.GetMedicineList();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<MedicineDTO> GetMedicineById(int id)
        {
            var response = _medicineService.GetMedicineById(id);

            return Ok(response);
        }

        [HttpPost("Create")]
        public ActionResult<MedicineDTO> CreateMedicine([FromBody] MedicineViewModel product)
        {
            var response = _medicineService.CreateMedicine(product);

            return Ok(response);
        }
        
        [HttpPut("Modify/{id}")]
        public ActionResult <List<MedicineDTO>> ModifyMedicine(int id, [FromBody] MedicineViewModel product)
        {
            var response = _medicineService.ModifyMedicine(id, product);

            return Ok(response);
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult<MedicineDTO> RemoveMedicine(int id)
        {
            var response = _medicineService.RemoveMedicine(id);

            return Ok(response);
        }
    }
}
