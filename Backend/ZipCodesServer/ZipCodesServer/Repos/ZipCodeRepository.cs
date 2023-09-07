using MongoDB.Driver;
using ZipCodesServer.Data;
using ZipCodesServer.Models;

namespace ZipCodesServer.Repos
{
    public class ZipCodeRepository : IZipCodeRepository
    {
        private readonly IZipCodeContext _context;

        public ZipCodeRepository(IZipCodeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ZipCodeHistory>> GetProducts()
        {
            return await _context
                            .ZipCodeHistoric
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<ZipCodeHistory> GetProduct(string id)
        {
            return await _context
                           .ZipCodeHistoric
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ZipCodeHistory>> GetZipCodesByCountryAndCity(string country, string city)
        {
            FilterDefinition<ZipCodeHistory> filter = Builders<ZipCodeHistory>.Filter.Eq(p => p.CountryAbbreviation, country.ToUpperInvariant() );

            var filtyeredByCode = await _context
                      .ZipCodeHistoric
                      .Find(filter)
                      .ToListAsync();
            return filtyeredByCode.Where(x => x.Places.Any(c => c.Name.Equals(city, StringComparison.InvariantCultureIgnoreCase ))).ToList();
        }

        public async Task<IEnumerable<ZipCodeHistory>> GetZipCodesByCountryAndCode(string country, string code)
        {
            FilterDefinition<ZipCodeHistory> codeFilter = Builders<ZipCodeHistory>.Filter.Eq(p => p.PostCode, code);

          var filtyeredByCode =  await _context
                            .ZipCodeHistoric
                            .Find(codeFilter)
                            .ToListAsync();
            return filtyeredByCode.Where(x => x.CountryAbbreviation.Equals(country, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }


        public async Task Create(ZipCodeHistory product)
        {
            await _context.ZipCodeHistoric.InsertOneAsync(product);
        }

        public async Task<bool> Update(ZipCodeHistory product)
        {
            var updateResult = await _context
                                        .ZipCodeHistoric
                                        .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<ZipCodeHistory> filter = Builders<ZipCodeHistory>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .ZipCodeHistoric
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
