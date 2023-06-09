using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Customer> GetById(int id);

       Task<Customer> GetByIdCard(string idCard);

       Task<Customer> GetFullDetailsByIdCard(string idCard);

        Task SaveChanges();
    }
}