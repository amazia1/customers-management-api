using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .Property(c => c.IdCard)
            .IsRequired()
            .HasMaxLength(9);

            modelBuilder.Entity<Customer>()
            .HasIndex(c => c.IdCard)
            .IsUnique();
        }

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Contract> Contracts => Set<Contract>();

        public DbSet<Package> Packages => Set<Package>();
    }
}