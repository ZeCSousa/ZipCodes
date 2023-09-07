using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ZipCodesServer.Models
{
    public class ZipCode
    {
 
        [JsonPropertyName("post code")]
        
        public string PostCode { get; set; }

        [JsonPropertyName("country")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Country { get; set; }

        [JsonPropertyName("country abbreviation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CountryAbbreviation { get; set; }

        [JsonPropertyName("places")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Place> Places { get; set; }
    }
}
