using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Models;
using Models.DTO;
using Services.Implementations;
using Services.Interfaces;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUserList")]
        public ActionResult<List<UserDTO>> GetUserList()
        {
            var response = _userService.GetUserList();
            return Ok(response);
        }
        [HttpGet("GetUserByid/{id}")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            var response = _userService.GetUserById(id);
            return Ok(response);
        }
        [HttpPost("CreateUser")]
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO user)
        {
            var response = _userService.CreateUser(user);

            return Ok(response);
        }

        [HttpPut("PutUser/{id}")]
        public ActionResult <List<User>> ModifyUser(int id, [FromBody] UserDTO user)
        {
            var response = _userService.ModifyUser(id, user);

            return Ok(response);
        }
        [HttpDelete("DeleteUser/{id}")]
        public ActionResult<User> RemoveUser(int id)
        {
            var response = _userService.RemoveUser(id);

            return Ok(response);
        }
    }
}
