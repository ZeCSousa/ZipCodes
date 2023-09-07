using ZipCodesServer.Models;

namespace ZipCodesServer.Repos
{
    public interface IZipCodeRepository
    {
        Task<IEnumerable<ZipCodeHistory>> GetProducts();
        Task<ZipCodeHistory> GetProduct(string id);
        Task<IEnumerable<ZipCodeHistory>> GetZipCodesByCountryAndCity(string country, string city);
        Task<IEnumerable<ZipCodeHistory>> GetZipCodesByCountryAndCode(string country,string code);

        Task Create(ZipCodeHistory product);
        Task<bool> Update(ZipCodeHistory product);
        Task<bool> Delete(string id);
    }
}