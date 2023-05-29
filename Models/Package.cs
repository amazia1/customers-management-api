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
    }
}