using ZipCodesServer.Models;

namespace ZipCodesServer.Services
{
    public interface IZipCodeService
    {
        Task<ZipCode?> GetZipCodeAsync(string country, string code);
    }
}