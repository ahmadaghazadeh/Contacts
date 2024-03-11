using ContactContext.Application.Contract.Contacts;
using ContactContext.Facade.Contract.Contacts;
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

       
    }
}
