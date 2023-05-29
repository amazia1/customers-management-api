using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ApiResponse<IEnumerable<GetCustomerDto>>> GetAllCustomers();

        Task<ApiResponse<GetCustomerDto>> GetCustomerById(int id);
    }
}