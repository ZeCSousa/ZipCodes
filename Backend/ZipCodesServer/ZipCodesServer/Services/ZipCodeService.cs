using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using ZipCodesServer.Models;

namespace ZipCodesServer.Services
{
    public class ZipCodeService
    {

        readonly HttpClient _httpClient;

        public ZipCodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ZipCode?> GetZipCodeAsync(string country, string code) =>
            await _httpClient.GetFromJsonAsync<ZipCode>($"{country}/{code}");


    }
}
