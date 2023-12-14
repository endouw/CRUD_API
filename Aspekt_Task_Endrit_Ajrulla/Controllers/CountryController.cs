using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;
using Aspekt_Task_Endrit_Ajrulla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt_Task_Endrit_Ajrulla.Controllers
{
    [ApiController]
    [Route("api/Countries")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("GetCountry")]
        public async Task<IActionResult> GetCountry(int countryId)
        {
            try
            {
                var country = await _countryService.GetCountryById(countryId);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _countryService.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddCountry")]
        public async Task<IActionResult> AddCountry(CountryDto country)
        {
            try
            {
                await _countryService.AddCountry(country);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(CountryDto country)
        {
            try
            {
                await _countryService.UpdateCountry(country);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            try
            {
                await _countryService.DeleteCountry(countryId);
                return Ok(countryId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
