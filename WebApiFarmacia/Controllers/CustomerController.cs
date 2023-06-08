using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Implementations;
using Services.Interfaces;

namespace WebApiMedicines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomerList")]
        public ActionResult<List<CustomerDTO>> GetCustomerList()
        {
            var response = _customerService.GetCustomerList();
            return Ok(response);
        }
        [HttpGet("GetCustomerById/{id}")]
        public ActionResult<CustomerDTO> GetCustomerById(int id)
        {
            var response = _customerService.GetCustomerById(id);

            return Ok(response);
        }

        [HttpPost("PostCustomer")]
        public ActionResult<CustomerDTO> CreateCustomer([FromBody] CustomerDTO customer)
        {
            var response = _customerService.CreateCustomer(customer);

            return Ok(response);
        }
        //el put es necesario?
        [HttpPut("PutCustomer/{id}")]
        public ActionResult<CustomerDTO> ModifyCustomer(int id, [FromBody] CustomerDTO customer)
        {
            var response = _customerService.ModifyCustomer(id, customer);

            return Ok(response);
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public ActionResult<CustomerDTO> DeleteCustomer(int id)
        {
            var response = _customerService.RemoveCustomer(id);

            return Ok(response);
        }

    }


}
