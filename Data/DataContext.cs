using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Contract> Contracts => Set<Contract>();

        public DbSet<Package> Packages => Set<Package>();
    }
}