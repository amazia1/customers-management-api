using System.Text.Json.Serialization;

namespace Customers_Management.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PackageTypes
    {
        Standard = 1,

        Premium = 2,

        Platinum = 3
    }
}