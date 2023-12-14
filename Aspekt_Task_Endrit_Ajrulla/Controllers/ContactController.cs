using Aspekt_Task_Endrit_Ajrulla.Models;
using Aspekt_Task_Endrit_Ajrulla.Models.Dtos;
using Aspekt_Task_Endrit_Ajrulla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt_Task_Endrit_Ajrulla.Controllers
{

    [ApiController]
    [Route("api/Contacts")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("GetContact")]
        public async Task<IActionResult> GetContact(int contactId)
        {
            try
            {
                var contact = await _contactService.GetContactById(contactId);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await _contactService.GetContacts();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddContact(ContactDto contact)
        {
            try
            {
                await _contactService.AddContact(contact);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateContact")]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            try
            {
                await _contactService.UpdateContact(contact);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteContact")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            try
            {
                await _contactService.DeleteContact(contactId);
                return Ok(contactId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetContactWithCompanyAndCountry")]
        public async Task<IActionResult> GetContactWithCompanyAndCountry(int id)
        {
            try
            {
                var result = await _contactService.GetContactWithCompanyAndCountry(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetContactWithCompanyAndCountryFilter")]
        public async Task<IActionResult> GetContactWithCompanyAndCountryFilter(int companyId, int countryId)
        {
            try
            {
                var result = await _contactService.GetContactWithCompanyAndCountryFilter(companyId, countryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
