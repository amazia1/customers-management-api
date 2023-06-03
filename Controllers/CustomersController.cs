using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Management.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse<IEnumerable<GetCustomerDto>>>> Get()
        {
            return Ok(await this._customerService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<GetCustomerDto>>> GetSingle(int id)
        {
            return Ok(await this._customerService.GetCustomerById(id));
        }

        [HttpGet("GetByIdCard/{idCard}")]
        public async Task<ActionResult<ApiResponse<GetCustomerDto>>> GetByIdCard(string idCard)
        {
            return Ok(await this._customerService.GetCustomerByIdCard(idCard));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<GetCustomerDto>>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
        {
            var response = await _customerService.UpdateCustomer(updatedCustomer);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}