
using ZipCodesServer.Controllers;
using ZipCodesServer.Services;
using Moq;

using Microsoft.AspNetCore.Mvc;
using ZipCodesServer.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ZipCodesServer.Repos;

namespace ZipCodeServerTests
{
    [TestClass]
    public class ZipCodesControllerTests
    {
        // Mock the service that provides the zip codes data
        private Mock<IZipCodeService> _mockZipCodeService;
        private Mock<IMemoryCache> _mockMemmoryCache;
        private Mock<IZipCodeRepository> _mockZipCodeRepository;
        private Mock<ILogger<ZipCodesController>> _mockLogger;

        // Create an instance of the controller to test
        private ZipCodesController _controller;

        // Initialize the mock and the controller before each test
        [TestInitialize]
        public void Setup()
        {
            _mockZipCodeService = new Mock<IZipCodeService>();
            _mockMemmoryCache = new Mock<IMemoryCache>();
            _mockZipCodeRepository = new Mock<IZipCodeRepository>();
            _mockLogger = new Mock<ILogger<ZipCodesController>>();
            _controller = new ZipCodesController(_mockZipCodeService.Object, _mockMemmoryCache.Object, _mockLogger.Object, _mockZipCodeRepository.Object);
        }

        // Test the GetZipCodeByCountry method with a valid country name
        [TestMethod]
        public async Task GetZipCodeByCountry_WithValidCountry_ReturnsOkResult()
        {
            // Arrange
            string country = "PT";
            string code = "2135-000";
            var place = new Place { Latitude = "0", Longitude = "0", Name = "namor", State = "statement", StateAbbreviation = "st" };
            var zipCodes = new ZipCode { PostCode = "2135-000", Country = "Portugal", CountryAbbreviation = "PT", Places = new List<Place>() { place} };

            _mockZipCodeService.Setup(s => s.GetZipCodeAsync(country, code)).ReturnsAsync(zipCodes);
            //_mockMemmoryCache.Setup(m => m.Set<ZipCode>($"country:{country}/code:{code}", zipCodes, TimeSpan.FromHours(24))).Returns(zipCodes);
           // _mockMemmoryCache.Setup(x => x.CreateEntry( It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>); ;
            var cacheEntryMock = new Mock<ICacheEntry>();
            _mockMemmoryCache.Setup(x => x.CreateEntry(It.IsAny<object>())).Returns(cacheEntryMock.Object);
            cacheEntryMock.SetupAllProperties();
            
            // Act
            var result = await _controller.GetZipCode(country, code);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(zipCodes, okResult.Value);
        }

        // Test the GetZipCodeByCountry method with an invalid country name
        [TestMethod]
        public async Task GetZipCodeByCountry_WithInvalidCountry_ReturnsNotFoundResult()
        {
            // Arrange
            string country = "NN";
            string code = "1234-123";
            ZipCode zipCode = null;
            _mockZipCodeService.Setup(s => s.GetZipCodeAsync(country, code)).ReturnsAsync(zipCode);

            // Act
            var result = await _controller.GetZipCodeByCountry(country);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}