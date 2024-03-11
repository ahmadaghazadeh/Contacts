using ContactContext.Application.Contract.Contacts;
using ContactContext.Facade.Contract.Contacts;
using CustomerContext.Application.Contract.Customers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactCommandFacade _contactCommandFacade;

        public ContactController(IContactCommandFacade contactCommandFacade)
        {
            this._contactCommandFacade = contactCommandFacade;
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

    }
}
