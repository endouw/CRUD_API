using Aspekt_Task_Endrit_Ajrulla.Models;
using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;

namespace Aspekt_Task_Endrit_Ajrulla.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<List<Company>> GetCompanies();

        public Task<Company> GetCompanyById(int id);

        public Task<long> AddCompany(CompanyDto company);

        public Task<bool> UpdateCompany(CompanyDto company);

        public Task<bool> DeleteCompany(int id);


    }
}
