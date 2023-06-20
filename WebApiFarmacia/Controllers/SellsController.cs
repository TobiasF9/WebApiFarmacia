﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Models.DTO;
using Models.ViewModel;
using Services.Interfaces;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellsController : ControllerBase
    {
        private readonly ISellsService _sellsService;

        public SellsController(ISellsService sellsService)
        {
            _sellsService = sellsService;
        }

        [HttpGet("GetSellsList")]
        public ActionResult<List<SellsDTO>> GetSellsList()
        {
            var response = _sellsService.GetSellsList();
            return Ok(response);
        }

        [HttpGet("GetSellsById/{id}")]
        public ActionResult<SellsDTO> GetsSellId(int id)
        {
            var response = _sellsService.GetSellById(id);

            return Ok(response);
        }

        [HttpPost("PostSells")]
        public ActionResult<SellsDTO> CreateSell([FromBody] SellsViewModel sell)
        {
            var response = _sellsService.CreateSell(sell);

            return Ok(response);
        }

        [HttpPut("PutSells/{id}")]
        public ActionResult<Sells> ModifySell(int id, [FromBody] SellsViewModel sell)
        {
            var response = _sellsService.ModifySell(id, sell);

            return Ok(response);
        }
        [HttpDelete("DeleteSells/{id}")]
        public ActionResult<Sells> RemoveMedicine(int id)
        {
            var response = _sellsService.RemoveSell(id);

            return Ok(response);
        }
    }
}
