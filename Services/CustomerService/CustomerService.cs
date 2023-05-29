using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Services.CustomerService
{
  public class CustomerService : ICustomerService
  {
    private readonly IMapper _mapper;
    public CustomerService(IMapper mapper)
    {
      this._mapper = mapper;
    }

    public Task<ApiResponse<IEnumerable<Customer>>> GetAllCustomers()
    {
      throw new NotImplementedException();
    }

    public Task<ApiResponse<Customer>> GetCustomerById()
    {
      throw new NotImplementedException();
    }
  }
}