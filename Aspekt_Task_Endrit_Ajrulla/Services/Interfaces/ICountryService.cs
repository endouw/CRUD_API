using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;
using Aspekt_Task_Endrit_Ajrulla.Models;

namespace Aspekt_Task_Endrit_Ajrulla.Services.Interfaces
{
    public interface ICountryService
    {
        public Task<List<Country>> GetCountries();

        public Task<Country> GetCountryById(int id);

        public Task<long> AddCountry(CountryDto UpdatedContact);

        public Task<bool> UpdateCountry(CountryDto company);

        public Task<bool> DeleteCountry(int id);

    }
}
