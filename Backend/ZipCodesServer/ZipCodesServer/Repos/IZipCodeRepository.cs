using ZipCodesServer.Models;

namespace ZipCodesServer.Repos
{
    public interface IZipCodeRepository
    {
        Task<List<ZipCodeHistory>> GetZipCodes(string country);
        Task<List<ZipCodeHistory>> GetZipCodes();
        Task<ZipCodeHistory> GetZipCode(string id);
        Task<List<ZipCodeHistory>> GetZipCodesByCountryAndCity(string country, string city);
        Task<List<ZipCodeHistory>> GetZipCodesByCountry(string country);
        Task<List<ZipCodeHistory>> GetZipCodesByCountryAndCode(string country,string code);

        Task Create(ZipCodeHistory zipCode);
        Task<bool> Update(ZipCodeHistory zipCode);
        Task<bool> Delete(string id);
    }
}