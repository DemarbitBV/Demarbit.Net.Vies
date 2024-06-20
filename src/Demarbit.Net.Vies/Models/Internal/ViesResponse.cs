using System.Text.Json.Serialization;

namespace Demarbit.Net.Vies.Models.Internal
{
    internal class ViesResponse
    {
        [JsonPropertyName("isValid")]
        public bool IsValid { get; set; }

        [JsonPropertyName("requestDate")]
        public DateTime RequestDate { get; set; }

        [JsonPropertyName("userError")]
        public string UserError { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("requestIdentifier")]
        public string RequestIdentifier { get; set; } = null!;

        [JsonPropertyName("vatNumber")]
        public string VatNumber { get; set; } = default!;
    }
}
