using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Services.Customer
{
  public class CustomerService : ICustomerService
  {
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _repository;
    
    public CustomerService(IMapper mapper, ICustomerRepository repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<GetCustomerDto>>> GetAllCustomers()
    {
        var response = new ApiResponse<IEnumerable<GetCustomerDto>>();

        try
        {
            var customers = await _repository.GetAll();
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
            var customer = await _repository.GetById(id);

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

    public async Task<ApiResponse<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
    {
        var response = new ApiResponse<GetCustomerDto>();

        try
        {
            var customer = await _repository.GetById(updatedCustomer.Id);

            if (customer is null)
                throw new Exception($"Customer {updatedCustomer.Id} not found");

            customer.City = updatedCustomer.City;
            customer.Street = updatedCustomer.Street;
            customer.HouseNumber = updatedCustomer.HouseNumber;
            customer.ZipCode = updatedCustomer.ZipCode;
            
            await _repository.SaveChanges();

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