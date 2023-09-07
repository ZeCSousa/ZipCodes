using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ZipCodesServer.Models;
using ZipCodesServer.Repos;
using ZipCodesServer.Services;

namespace ZipCodesServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ZipCodesController : ControllerBase
    {
        private ZipCodeService _zipCodeService;
        private readonly IMemoryCache memoryCache;
        private readonly ILogger<ZipCodesController> _logger;
        private readonly IZipCodeRepository _repository;

        public ZipCodesController(ZipCodeService zipCodeService, IMemoryCache memoryCache,
            ILogger<ZipCodesController> logger, IZipCodeRepository zipCodeRepository)
        {
            _zipCodeService = zipCodeService;
            this.memoryCache = memoryCache;
            _logger = logger;
            _repository = zipCodeRepository;
        }

        [HttpGet("getCity/{country}/{code}", Name = "GetZipCodeByCountryAndCode")]
        public async Task<ActionResult> GetZipCode(string country, string code)
        {
            ZipCode zipcode = null;// memoryCache.Get<ZipCode>($"country:{country}/code:{code}");

            if (zipcode == null)
            {
                try
                {
                    zipcode = await _zipCodeService.GetZipCodeAsync(country, code);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    return BadRequest("Failed to retrieve zip code from external API.");
                }


                if (zipcode != null)
                {
                    memoryCache.Set<ZipCode>($"country:{country}/code:{code}", zipcode, TimeSpan.FromHours(24));
                    IEnumerable<ZipCodeHistory> z = null;
                    try
                    {
                        z = await _repository.GetZipCodesByCountryAndCode(country, code);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }

                    if (z.Count() > 0)
                    {
                        var zip = z.First();
                        zip.SearchedTimes++;
                        await _repository.Update(zip);
                    }
                    else
                    {
                        var zip = new ZipCodeHistory();
                        zip.Places = zipcode.Places;
                        zip.PostCode = zipcode.PostCode;
                        zip.Country = zipcode.Country;
                        zip.CountryAbbreviation = zipcode.CountryAbbreviation;
                        zip.SearchedTimes = 1;
                        try
                        {
                            await _repository.Create(zip);
                        }
                        catch (Exception exc)
                        {
                            _logger.LogError(exc.Message);
                        }

                    }


                }
            }

            return Ok(new ZipCode() { CountryAbbreviation = zipcode.CountryAbbreviation, Country = zipcode.Country, Places = zipcode.Places, PostCode = zipcode.PostCode });

        }

        [HttpGet("getCode/{country}/{city}", Name = "GetZipCodeByCountryAndCity")]
        public async Task<ActionResult> GetZipCodeByCity(string country, string city)
        {
            var zipcode = memoryCache.Get<ZipCode>($"{country}/{city}");

            if (zipcode == null)
            {

                IEnumerable<ZipCodeHistory> z = null;
                try
                {
                    z = await _repository.GetZipCodesByCountryAndCity(country, city);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                if (z.Any())
                {
                    z.ToList().ForEach(async e =>
                    {
                        e.SearchedByName++;

                        await _repository.Update(e);
                    });


                    return Ok(z.Select(zipc =>
                    {
                        var zip = new ZipCode();
                        zip.PostCode = zipc.PostCode;
                        return zip;
                    }));

                }
                else
                {
                    return NotFound();

                }



            }

            return Ok(zipcode);

        }





    }
}
