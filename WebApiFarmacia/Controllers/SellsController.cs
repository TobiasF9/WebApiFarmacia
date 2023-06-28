﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Models.DTO;
using Models.ViewModel;
using Services.Implementations;
using Services.Interfaces;
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
        public ActionResult<List<SellsDTO>> GetSellsList()
        {
            try
            {
                var response = _sellsService.GetSellsList();
                if (response.Count == 0)
                {
                    NotFound("There is not sells");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetAll", ex);
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<SellsDTO> GetsSellId(int id)
        {
            try
            {
                var response = _sellsService.GetSellById(id);
                return Ok(response);
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
                var response = _sellsService.CreateSell(sell);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Sells/GetById";
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
        public ActionResult<SellsDTO> ModifySell([FromBody] SellsViewModel sell)
        {
            try
            {
                var response = _sellsService.ModifySell(sell);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Sells/GetById";
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
        public ActionResult<Sells> RemoveSells(int id)
        {
            try
            {
                var response = _sellsService.RemoveSell(id);

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
