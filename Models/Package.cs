using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers_Management.Models
{
    public class Package
    {
        public int Id { get; set; }

        public PackageTypes PackageType { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Amount { get; set; }

        public int Usage { get; set; }

        public List<Contract>? Contracts { get; set; }
    }
}