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
using System.Security.Claims;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Authorize]
        public ActionResult<List<MedicineDTO>> GetMedicineList()
        {

            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "User" || HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _medicineService.GetMedicineList();
                if (response.Count == 0)
                {
                    return NotFound("There is no medicine");
                }
                return Ok(response);
                }
                throw new Exception("You don't have the User or Administrator role");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetAll", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpGet("GetById")]
        [Authorize]
        public ActionResult<MedicineDTO> GetMedicineById(int id)
        {
            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "User" || HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _medicineService.GetMedicineById(id);
                return Ok(response);
                }
                throw new Exception("You don't have the User or Administrator role");
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
        [HttpGet("GetMedicineMostSelled")]
        [Authorize]
        public ActionResult<List<MedicineDTO>> GetMedicineMostSelled()
        {

            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _medicineService.GetMedicineMostSelled();
                if (response == null)
                {
                    return NotFound("There is no medicine sold");
                }
                return Ok(response);
                }
                throw new Exception("You don't have the Administrator role");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetAll", ex);
                return BadRequest($"{ex.Message}");
            }

        }

        [HttpPost("Create")]
        [Authorize]
        public ActionResult<MedicineDTO> CreateMedicine([FromBody] MedicineViewModel product)
        {
            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _medicineService.CreateMedicine(product);
                
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Medicine/GetById";
                string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{response.Id}";
                return Created(locationUrl, response);
                }
                throw new Exception("You don't have the Administrator role");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Create", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }
        
        [HttpPut("Modify")]
        [Authorize]
        public ActionResult <MedicineDTO> ModifyMedicine([FromBody] MedicineViewModel product)
        {

            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _medicineService.ModifyMedicine(product);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Medicine/GetById";
                string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{response.Id}";
                return Created(locationUrl, response);
                }
                throw new Exception("You don't have the Administrator role");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Modify", ex);
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpDelete("Delete")]
        [Authorize]
        public ActionResult<MedicineDTO> RemoveMedicine(int id)
        {

            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _medicineService.RemoveMedicine(id);

                return Ok(response);
                }
                throw new Exception("You don't have the Administrator role");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Delete", ex);
                return BadRequest($"{ex.Message}");
            }

            
        }
    }
}
