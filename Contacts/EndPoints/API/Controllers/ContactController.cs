using ContactContext.Application.Contract.Contacts;
using ContactContext.Facade.Contract.Contacts;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Application.Contract.Contacts;
using ReadModel.Application.Contract.Contacts.Dto;
using ReadModel.Facade.Contacts;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactCommandFacade _contactCommandFacade;
        private readonly IContactsQueryFacade _contactQueryFacade;

		public ContactController(IContactCommandFacade contactCommandFacade, IContactsQueryFacade contactQueryFacade)
		{
			_contactCommandFacade = contactCommandFacade;
			_contactQueryFacade = contactQueryFacade;
		}
 

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _contactCommandFacade.CreateContact(command);
            return Ok();
        }

        // This thing doesn't correct in the real business.
        [HttpDelete("{lastName}/{firstName}")]
        public async Task<IActionResult> DeleteContact(string lastName, string firstName)
        {
            var command = new DeleteContactCommand { LastName = lastName, FirstName= firstName };
            await _contactCommandFacade.DeleteContact(command);
            return Ok();
        }
        // This thing doesn't correct in the real business.

        [HttpPut("{lastName}/{firstName}")]
        public async Task<IActionResult> UpdateContact(string lastName, string firstName, UpdateContactCommand command)
        {
            command.FirstName = firstName;
            command.LastName = lastName;
            await _contactCommandFacade.UpdateContact(command);
            return Ok();
        }

        [HttpGet]
        public async Task<List<ContactDto>> GetAllContacts()
        {
	        var command = new GetAllContactsQuery();
	        return await _contactQueryFacade.GetAllContractsAsync(command);
        }

	}
}
