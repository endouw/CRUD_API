using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;
using Aspekt_Task_Endrit_Ajrulla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt_Task_Endrit_Ajrulla.Controllers
{
    [ApiController]
    [Route("api/Companies")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService) 
        { 
        _companyService = companyService;
        }

        [HttpGet]
        [Route("GetCompany")]
        public async Task<IActionResult> GetCompany(int companyId)
        {
            try
            {
                var company = await _companyService.GetCompanyById(companyId);
                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyService.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddCompany")]
        public async Task<IActionResult> AddCompany(CompanyDto company)
        {
            try
            {
                await _companyService.AddCompany(company);
                return Ok(company);
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateCompany")]
        public async Task<IActionResult> UpdateCompany(CompanyDto company)
        {
            try
            {
                await _companyService.UpdateCompany(company);
                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            try
            {
                await _companyService.DeleteCompany(companyId);
                return Ok(companyId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
