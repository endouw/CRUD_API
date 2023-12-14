using Aspekt_Task_Endrit_Ajrulla.DataContext;
using Aspekt_Task_Endrit_Ajrulla.Models;
using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;
using Aspekt_Task_Endrit_Ajrulla.Services.Interfaces;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace Aspekt_Task_Endrit_Ajrulla.Services
{
    public class ContactService : IContactService
    {
        private readonly ClientContext _dbContext;
        private readonly ILogger<ContactService> _logger;
        private readonly ICompanyService _companyService;
        private readonly ICountryService _countryService;

        public ContactService(ClientContext dbContext, ILogger<ContactService> logger, ICompanyService companyService, ICountryService countryService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _companyService = companyService;
            _countryService = countryService;
        }

        public async Task<List<Contact>> GetContacts()
        {
            var contacts = new List<Contact>();
            try
            {
                contacts = await _dbContext.Contacts.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return contacts;

        }



        public async Task<Contact> GetContactById(int id)
        {
            var contact = new Contact();
            try
            {
                contact = await _dbContext.Contacts.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return contact;
        }

      

        public async Task<long> AddContact(ContactDto contact)
        {
            var contactFormat = new Contact();
            contactFormat.ContactId = contact.ContactId;
            contactFormat.ContactName = contact.ContactName;
            contactFormat.CountryId = contact.CountryId;
            contactFormat.CompanyId = contact.CompanyId;
            

            try
            {
                var InsertedContact = await _dbContext.Contacts.AddAsync(contactFormat);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return 0;
        }

        public async Task<bool> UpdateContact(Contact UpdatedContact)
        {
            var contact = new Contact();
            try
            {
                contact = await GetContactById(UpdatedContact.ContactId);
                if (contact != null)
                {
                    contact.ContactId = UpdatedContact.ContactId;
                    contact.ContactName = UpdatedContact.ContactName;
                    contact.Company.CompanyName = UpdatedContact.Company.CompanyName;
                    contact.Country.CountryName = UpdatedContact.Country.CountryName;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return true;
        }


        public async Task<bool> DeleteContact(int id)
        {
            try
            {
                var contact = await GetContactById(id);

                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return true;

        }

        public async Task<ContactWithCompanyAndCountryDto> GetContactWithCompanyAndCountry(int id)
        {
            var ContactWithCompanyAndCountry = new ContactWithCompanyAndCountryDto();  

            try
            {
                var Client = await GetContactById(id);
                var Country = await _countryService.GetCountryById(Client.CountryId);
                var Company = await _companyService.GetCompanyById(Client.CompanyId);
                if (Client != null && Country !=null && Company !=null )
                {
                    ContactWithCompanyAndCountry.ContactId = Client.ContactId;
                    ContactWithCompanyAndCountry.ContactName = Client.ContactName;
                    ContactWithCompanyAndCountry.CompanyName = Company.CompanyName;
                    ContactWithCompanyAndCountry.CompanyId = Company.CompanyId;
                    ContactWithCompanyAndCountry.CountryName = Country.CountryName;
                    ContactWithCompanyAndCountry.CountryId = Country.CountryId; 
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }

            return ContactWithCompanyAndCountry;

        }

        public async Task<List<ContactWithCompanyAndCountryDto>> GetContactWithCompanyAndCountryFilter(int companyId, int countryId)
        {
            var ContactWithCompanyAndCountryList = new List<ContactWithCompanyAndCountryDto>();


            try
            {
                if (countryId >= 1 && companyId >= 1)
                {
                    var Contact = _dbContext.Contacts.Where(x => x.CompanyId == companyId && x.CountryId == countryId).ToList();
                    foreach (var item in Contact)
                    {
                        //insert Name and Id of Contact

                        var ContactWithCompanyAndCountry = new ContactWithCompanyAndCountryDto();
                        ContactWithCompanyAndCountry.ContactName = item.ContactName;
                        ContactWithCompanyAndCountry.ContactId = item.ContactId;

                        var Country = await _countryService.GetCountryById(countryId);
                        var Company = await _companyService.GetCompanyById(companyId);

                        //insert Company Name and Id

                        ContactWithCompanyAndCountry.CompanyName = Company.CompanyName;
                        ContactWithCompanyAndCountry.CompanyId = Company.CompanyId;

                        //insert Country Name and Id

                        ContactWithCompanyAndCountry.CountryId = Country.CountryId;
                        ContactWithCompanyAndCountry.CountryName = Country.CountryName;

                        //Add final object

                        ContactWithCompanyAndCountryList.Add(ContactWithCompanyAndCountry);
                        _dbContext.SaveChanges();
                    }
  
                }
                else if (countryId >= 1)
                {
                    var Contact = _dbContext.Contacts.Where(x => x.CountryId == countryId).ToList();

                    foreach(var item in Contact)
                    {
                        //insert Name and Id of Contact

                        var ContactWithCompanyAndCountry = new ContactWithCompanyAndCountryDto();
                        ContactWithCompanyAndCountry.ContactName = item.ContactName;
                        ContactWithCompanyAndCountry.ContactId = item.ContactId;

                        var Country = await _countryService.GetCountryById(countryId);
                        //insert Country Name and Id

                        ContactWithCompanyAndCountry.CountryName = Country.CountryName;
                        ContactWithCompanyAndCountry.CountryId = Country.CountryId;

                        //Add final object

                        ContactWithCompanyAndCountryList.Add(ContactWithCompanyAndCountry);
                        _dbContext.SaveChanges();

                    }

                }
                else if (companyId >= 1)
                {
                    var Contact = _dbContext.Contacts.Where(x => x.CompanyId == companyId).ToList();

                    foreach(var item in Contact)
                    {
                        //insert Name and Id of Contact
                        var ContactWithCompanyAndCountry = new ContactWithCompanyAndCountryDto();
                        ContactWithCompanyAndCountry.ContactName = item.ContactName;
                        ContactWithCompanyAndCountry.ContactId = item.ContactId;

                        //insert Company Name and Id
                        var Company = await _companyService.GetCompanyById(companyId);
                        ContactWithCompanyAndCountry.CompanyName = Company.CompanyName;
                        ContactWithCompanyAndCountry.CompanyId = Company.CompanyId;

                        //Add final object

                        ContactWithCompanyAndCountryList.Add(ContactWithCompanyAndCountry);
                        _dbContext.SaveChanges();

                    }

                }
                else
                {
                    throw new InvalidOperationException("No data was found");
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }

            return ContactWithCompanyAndCountryList;

        }
    }
}
