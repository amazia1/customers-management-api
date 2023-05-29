using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public string IdCard { get; set; } = string.Empty;

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? HouseNumber { get; set; }

        public string? ZipCode { get; set; }

        public List<Contract>? Contracts { get; set; }
    }
}