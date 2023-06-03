using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Repositories.Customers
{
  public class CustomerRepository : ICustomerRepository
  {
      private readonly DataContext _context;

      public CustomerRepository(DataContext context)
      {
          this._context = context;
      }

      public async Task<IEnumerable<Customer>> GetAll()
      {
          return await _context.Customers
          .Include(c => c.Contracts)!
          .ThenInclude(p => p.Packages)
          .ToListAsync();
      }

      public async Task<Customer> GetById(int id)
      {
          var customer = await _context.Customers
            .Include(c => c.Contracts)!
            .ThenInclude(p => p.Packages)!
            .FirstOrDefaultAsync(c => c.Id == id);
            
          return customer!;
      }

      public async Task<Customer> GetByIdCard(string idCard)
      {
          var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.IdCard.Trim() == idCard.Trim());
          return customer!;
      }

      public async Task<Customer> GetFullDetailsByIdCard(string idCard)
      {
          var customer = await _context.Customers
            .Include(c => c.Contracts)!
            .ThenInclude(p => p.Packages)
            .FirstOrDefaultAsync(c => c.IdCard.Trim() == idCard.Trim());
            
          return customer!;
      }

      public async Task SaveChanges()
      {
        await _context.SaveChangesAsync();
      }
  }
}