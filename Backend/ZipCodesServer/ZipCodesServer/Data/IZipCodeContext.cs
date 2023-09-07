using MongoDB.Driver;
using ZipCodesServer.Models;

namespace ZipCodesServer.Data
{
    public interface IZipCodeContext
    {
        IMongoCollection<ZipCodeHistory> ZipCodeHistoric { get; }
    }
}
