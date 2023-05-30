using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Customers_Management.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public string ContractNumber { get; set; } = string.Empty;

        public string ContractName { get; set; } = string.Empty;

        public ContractTypes ContractType { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }

        public List<Package>? Packages { get; set; }
    }
}