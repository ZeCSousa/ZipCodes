using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ZipCodesServer.Models;
using ZipCodesServer.Settings;

namespace ZipCodesServer.Data
{
    public class ZipCodeContext : IZipCodeContext
    {

        public ZipCodeContext(ICatalogDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            ZipCodeHistoric = database.GetCollection<ZipCodeHistory>(settings.CollectionName);

        }


        public IMongoCollection<ZipCodeHistory> ZipCodeHistoric { get; }
    }
}
