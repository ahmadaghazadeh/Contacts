using ContactContext.Application.Contract.Contacts;
using ContactContext.Facade.Contract.Contacts;
using Framework.Facade;
using MediatR;

namespace ContactContext.Facade.Contacts
{
    public class ContactCommandFacade : FacadeCommandBase, IContactCommandFacade
    {
        public ContactCommandFacade(IMediator mediator) : base(mediator)
        {
        }


        public Task CreateContact(CreateContactCommand command)
        {
            return Mediator.Send(command);
        }
    }
}
