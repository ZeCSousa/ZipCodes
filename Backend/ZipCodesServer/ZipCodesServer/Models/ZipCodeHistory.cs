using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ZipCodesServer.Models
{
    [BsonIgnoreExtraElements]
    public class ZipCodeHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public long SearchedTimes { get; set; }
        public long SearchedByName { get; set; }

        public string PostCode { get; set; }
        public string Country { get; set; }

        public string CountryAbbreviation { get; set; }
       public List<Place> Places { get; set; }


    }
}
