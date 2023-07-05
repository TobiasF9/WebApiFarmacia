using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Models;
using Model.ViewModel;
using Models.DTO;
using Services.Implementations;
using Services.Interfaces;
using WebApiMedicines.Common;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<UserDTO>> GetUserList()
        {
            try
            {
                var response = _userService.GetUserList();
                if (response.Count == 0)
                {
                    return NotFound("There is no user");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetAll", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }
        [HttpGet("GetByid")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            try
            {
                var response = _userService.GetUserById(id);
                return Ok(response);
            }
            catch (Exception ex) when (ex.Message == "Sequence contains no elements")
            {
                return NotFound($"The user with id {id} was not found");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetById", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }
        [HttpPost("Create")]
        public ActionResult<UserDTO> CreateUser([FromBody] UserViewModel user)
        {
            try
            {
                var response = _userService.CreateUser(user);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/User/GetById";
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
        public ActionResult<UserDTO> ModifyUser([FromBody] UserViewModel user)
        {
            try
            {
                var response = _userService.ModifyUser(user);
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/User/GetById";
                string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Modify", ex);
                return BadRequest($"{ex.Message}");
            }
            
        }
        [HttpDelete("Delete")]
        public ActionResult<UserDTO> RemoveUser(int id)
        {
            try
            {
                var response = _userService.RemoveUser(id);
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
