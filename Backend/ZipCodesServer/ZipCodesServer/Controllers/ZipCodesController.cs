using Microsoft.AspNetCore.Mvc;

namespace ZipCodesServer.Controllers
{
    public class ZipCodesController : Controller
    {
        [HttpGet(Name = "GetZipCode")]
        public IEnumerable<WeatherForecast> Get()
        {
            
        }
    }
}
