using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Services.Authentication
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> IsCustomerExist(string idCard);
        
        string GenerateToken(string idCard);
    }
}