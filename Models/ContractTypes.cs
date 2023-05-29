using System.Text.Json.Serialization;

namespace Customers_Management.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum ContractTypes
    {
        Apartment = 1,

        Vehicle = 2,

        Travel = 3
    }
}