using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<ApiResponse<int>>> Get(string idCard)
        {
            var result = await this._service.IsCustomerExist(idCard);
            if (result.Success)
            {
                var token = this._service.GenerateToken(idCard);
                Response.Headers.Add("Authorization", $"Bearer {token}");
            }

            return Ok(result);
        }
    }
}