using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Models.DTO;
using Models.ViewModel;
using Services.Implementations;
using Services.Interfaces;
using System.Security.Claims;
using WebApiMedicines.Common;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly ISellsService _sellsService;
        private readonly ILogger<SellsController> _logger;

        public SellsController(ISellsService sellsService, ILogger<SellsController> logger)
        {
            _sellsService = sellsService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        [Authorize]
        public ActionResult<List<SellsDTO>> GetSellsList()
        {
            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _sellsService.GetSellsList();
                    if (response.Count == 0)
                    {
                        NotFound("There is not sells");
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

        [HttpGet("GetById")]
        public ActionResult<List<SellsDTO>> GetsSellId(int id)
        {
            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _sellsService.GetSellById(id);
                return Ok(response);
                }
                throw new Exception("You don't have the Administrator role");
            }
            catch (Exception ex) when (ex.Message == "Sequence contains no elements")
            {
                return NotFound($"The sell with id {id} was not found");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetById", ex);
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("Create")]
        public ActionResult<SellsDTO> CreateSell([FromBody] SellsViewModel sell)
        {
            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _sellsService.CreateSell(sell);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Sells/GetById";
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
        public ActionResult<SellsDTO> ModifySell([FromBody] SellsViewModel sell)
        {
            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _sellsService.ModifySell(sell);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Sells/GetById";
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
        public ActionResult<List<Sells>> RemoveSells(int id)
        {
            try
            {
                if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Admin")
                {
                    var response = _sellsService.RemoveSell(id);

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
