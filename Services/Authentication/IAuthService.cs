using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Services.Authentication
{
    public interface IAuthService
    {
        Task<ApiResponse<bool>> IsCustomerExist(string idCard);
    }
}