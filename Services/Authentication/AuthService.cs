using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Customers_Management.Services.Authentication
{
  public class AuthService : IAuthService
  {
    private readonly ICustomerRepository _repository;
    private readonly IConfiguration _configuration;

    public AuthService(ICustomerRepository repository, IConfiguration configuration)
    {
      this._configuration = configuration;
      this._repository = repository;
        
    }

    public async Task<ApiResponse<string>> IsCustomerExist(string idCard)
    {
        var response = new ApiResponse<string>();

        try
        {
            var customer = await _repository.GetByIdCard(idCard);

            if (customer is null)
                throw new Exception($"ID: {idCard} not found");

            response.Data = createToken(idCard);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }

    public string GenerateToken(string idCard)
    {
        return createToken(idCard);
    }

    private string createToken(string idCard)
    {
        var tokenExpiration = _configuration.GetSection("AppSettings:TokenExpirationInMinutes").Value;
        var appSecretToken = _configuration.GetSection("AppSettings:Token").Value;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, idCard)
        };

        if (appSecretToken is null)
            throw new Exception("App Token is null");

        SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(appSecretToken));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(int.Parse(tokenExpiration!)),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
  }
}