using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
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
        [HttpPost("PostMedicine")]
        public ActionResult<UserDTO> CreateUser([FromBody] UserDTO user)
        {
            var response = _userService.CreateUser(user);

            return Ok(response);
        }

        [HttpPut("PutMedicine/{id}")]
        public ActionResult<UserDTO> ModifyUser(int id, [FromBody] UserDTO user)
        {
            var response = _userService.ModifyUser(id, user);

            return Ok(response);
        }
        [HttpDelete("DeleteMedicine/{id}")]
        public ActionResult<UserDTO> RemoveUser(int id)
        {
            var response = _userService.RemoveUser(id);

            return Ok(response);
        }
    }
}
