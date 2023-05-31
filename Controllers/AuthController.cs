using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            this._service = service;
        }

        [HttpGet("{idCard}")]
        public async Task<ActionResult<ApiResponse<bool>>> Get(string idCard)
        {
            return Ok(await this._service.IsCustomerExist(idCard));
        }
    }
}