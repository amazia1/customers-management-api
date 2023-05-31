using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Services.Authentication
{
  public class AuthService : IAuthService
  {
    private readonly ICustomerRepository _repository;

    public AuthService(ICustomerRepository repository)
    {
      this._repository = repository;
        
    }
    public async Task<ApiResponse<bool>> IsCustomerExist(string idCard)
    {
        var response = new ApiResponse<bool>();

        try
        {
            var isExist = await _repository.CheckIdExist(idCard);

            if (isExist == false)
                throw new Exception($"IdCard: {idCard} not found");

            response.Data = isExist;
        }
        catch (Exception ex)
        {
            response.Data = false;
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }
  }
}