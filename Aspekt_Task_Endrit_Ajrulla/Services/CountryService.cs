using Aspekt_Task_Endrit_Ajrulla.DataContext;
using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;
using Aspekt_Task_Endrit_Ajrulla.Models;
using Aspekt_Task_Endrit_Ajrulla.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aspekt_Task_Endrit_Ajrulla.Services
{

    public class CountryService : ICountryService
    {
        private readonly ClientContext _dbContext;
        private readonly ILogger<CountryService> _logger;

        public CountryService(ClientContext dbContext, ILogger<CountryService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Country>> GetCountries()
        {
            var Countries = new List<Country>();
            try
            {
                Countries = await _dbContext.Countries.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return Countries;

        }

        public async Task<Country> GetCountryById(int id)
        {
            var Country = new Country();
            try
            {
                Country = await _dbContext.Countries.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return Country;
        }

        public async Task<long> AddCountry(CountryDto country)
        {
            var CountryFormat = new Country();
            CountryFormat.CountryId = country.CountryId;
            CountryFormat.CountryName = country.CountryName;
            try
            {
                var InsertedCountry = await _dbContext.Countries.AddAsync(CountryFormat);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return 0;
        }

        public async Task<bool> UpdateCountry(CountryDto UpdatedCountry)
        {
            var Country = new Country();
            try
            {
                Country = await GetCountryById(UpdatedCountry.CountryId);
                if (Country != null)
                {
                    Country.CountryId = UpdatedCountry.CountryId;
                    Country.CountryName = UpdatedCountry.CountryName;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return true;
        }


        public async Task<bool> DeleteCountry(int id)
        {
            try
            {
                var Company = await GetCountryById(id);

                _dbContext.Countries.Remove(Company);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return true;

        }

    }

}
