using Aspekt_Task_Endrit_Ajrulla.DataContext;
using Aspekt_Task_Endrit_Ajrulla.Models;
using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;
using Aspekt_Task_Endrit_Ajrulla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspekt_Task_Endrit_Ajrulla.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ClientContext _dbContext;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(ClientContext dbContext, ILogger<CompanyService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }   

        public async Task<List<Company>> GetCompanies()
        {
            var Companies = new List<Company>();    
            try
            {
                Companies = await _dbContext.Companies.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);
                
            }
            return Companies;

        }

        public async Task<Company> GetCompanyById(int id)
        {
            var company = new Company();
            try
            {
                company = await _dbContext.Companies.FindAsync(id);
            }
            catch(Exception e) 
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return company;
        }

        public async Task<long> AddCompany(CompanyDto company)
        {
            var CompanyFormat = new Company();
            CompanyFormat.CompanyId = company.CompanyId;
            CompanyFormat.CompanyName = company.CompanyName;
            try
            {
                var InsertedCompany = await _dbContext.Companies.AddAsync(CompanyFormat);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return 0;
        }

        public async Task<bool> UpdateCompany(CompanyDto Updatedcompany)
        {
            var company = new Company();
            try
            {
                company = await GetCompanyById(Updatedcompany.CompanyId);
                if (company != null)
                {
                    company.CompanyId = Updatedcompany.CompanyId;
                    company.CompanyName = Updatedcompany.CompanyName;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);

            }
            return true;    
        }


        public async Task<bool> DeleteCompany(int id)
        {
            try
            {
                var company = await GetCompanyById(id);

                _dbContext.Companies.Remove(company);
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
