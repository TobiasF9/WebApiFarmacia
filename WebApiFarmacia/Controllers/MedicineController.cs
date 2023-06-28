using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models.DTO;
using System.Collections.Generic;
using Services.Implementations;
using Services.Interfaces;
using Model.Models;
using Models.ViewModel;
using WebApiMedicines.Common;
using Microsoft.AspNetCore.Authorization;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly ILogger<MedicineController> _logger;

        public MedicineController(IMedicineService medicineService, ILogger<MedicineController> logger)
        {
            _medicineService = medicineService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<MedicineDTO>> GetMedicineList()
        {

            try
            {
                var response = _medicineService.GetMedicineList();
                if (response.Count == 0)
                {
                    return NotFound("There is no medicine");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                //el "getAll" de este log no está un poco generico?
                _logger.LogCustomError("GetAll", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<MedicineDTO> GetMedicineById(int id)
        {
            ////string? rol = User.Claims.FirstOrDefault(c => c.Properties.ContainsKey("role"))?.Value;
            ////if(rol == "admin")
            ////{
            ////    return Ok(_medicineService.GetMedicineById(id)); //corregir
            //}
            //return Unauthorized();
            try
            {
                var response = _medicineService.GetMedicineById(id);
                return Ok(response);
            }
            catch (Exception ex) when(ex.Message == "Sequence contains no elements")
            {
                return NotFound($"The medicine with id {id} was not found");
            } 
            catch (Exception ex)
            {
                _logger.LogCustomError("GetById", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpPost("Create")]
        public ActionResult<MedicineDTO> CreateMedicine([FromBody] MedicineViewModel product)
        {
            try
            {
                var response = _medicineService.CreateMedicine(product);
                
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Medicine/GetById";
                string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Create", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }
        
        [HttpPut("Modify")]
        public ActionResult <MedicineDTO> ModifyMedicine([FromBody] MedicineViewModel product)
        {

            try
            {
                var response = _medicineService.ModifyMedicine(product);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Medicine/GetById";
                string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Modify", ex);
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpDelete("Delete/{id}")]
        public ActionResult<MedicineDTO> RemoveMedicine(int id)
        {

            try
            {
                var response = _medicineService.RemoveMedicine(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Delete", ex);
                return BadRequest($"{ex.Message}");
            }

            
        }
    }
}
