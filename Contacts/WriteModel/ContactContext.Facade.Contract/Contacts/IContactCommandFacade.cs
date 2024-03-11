

using ContactContext.Application.Contract.Contacts;

namespace ContactContext.Facade.Contract.Contacts
{
    public interface IContactCommandFacade
    {
        Task CreateContact(CreateContactCommand command);

    }
}
