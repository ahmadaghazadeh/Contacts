﻿

using ContactContext.Application.Contract.Contacts;
using CustomerContext.Application.Contract.Customers;

namespace ContactContext.Facade.Contract.Contacts
{
    public interface IContactCommandFacade
    {
        Task CreateContact(CreateContactCommand command);

        Task DeleteContact(DeleteContactCommand command);
        Task UpdateContact(UpdateContactCommand command);

    }
}
