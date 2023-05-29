using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Services.CustomerService
{
  public class CustomerService : ICustomerService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public CustomerService(IMapper mapper, DataContext context)
    {
        this._mapper = mapper;
        this._context = context;
    }

    public async Task<ApiResponse<IEnumerable<GetCustomerDto>>> GetAllCustomers()
    {
        var response = new ApiResponse<IEnumerable<GetCustomerDto>>();

        try
        {
            var customers = await _context.Customers.ToListAsync();
            response.Data = customers.Select(c => _mapper.Map<GetCustomerDto>(c));
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }

    public async Task<ApiResponse<GetCustomerDto>> GetCustomerById(int id)
    {
        var response = new ApiResponse<GetCustomerDto>();

        try
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if (customer is null)
                throw new Exception($"Customer {id} not found");

            response.Data = _mapper.Map<GetCustomerDto>(customer);
        }
        catch (Exception ex)
        {
           response.Success = false;
           response.Message = ex.Message;
        }

        return response;
    }
  }
}