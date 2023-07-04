using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.DTO;
using Model.Models;
using Model.ViewModel;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiMedicines.Common;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService service, ILogger<AuthController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] AuthViewModel User)
        {
            string response = string.Empty;
            try
            {
                response = _service.Login(User);
                if (string.IsNullOrEmpty(response))
                    return NotFound("email/password erroneous");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Login", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }

        [HttpPost("CrearUsuario")]
        public ActionResult<string> CreateUser([FromBody] UserViewModel User)
        {
            string response = string.Empty;
            try
            {
                response = _service.CreateUser(User);
                if (response == "Enter a user" || response == "Existing user")
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("CreateUser", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }
    }
}
