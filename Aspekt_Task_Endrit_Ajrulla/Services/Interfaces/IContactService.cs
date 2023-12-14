using Aspekt_Task_Endrit_Ajrulla.Models;
using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;

namespace Aspekt_Task_Endrit_Ajrulla.Services.Interfaces
{
    public interface IContactService
    {
        public Task<List<Contact>> GetContacts();

        public Task<Contact> GetContactById(int id);

        public Task<long> AddContact(ContactDto contact);

        public Task<bool> UpdateContact(Contact company);

        public Task<bool> DeleteContact(int id);

        public Task<ContactWithCompanyAndCountryDto> GetContactWithCompanyAndCountry(int id);

        public Task<List<ContactWithCompanyAndCountryDto>> GetContactWithCompanyAndCountryFilter(int companyId, int countryId);


    }
}
