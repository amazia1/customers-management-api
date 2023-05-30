using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? HouseNumber { get; set; }

        public string? ZipCode { get; set; }
    }
}