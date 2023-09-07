using System.Text.Json.Serialization;

namespace ZipCodesServer.Models
{
    public class Place
    {

        [JsonPropertyName("place name")]
        public string Name { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }


    }
}