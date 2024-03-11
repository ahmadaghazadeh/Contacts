using ReadModel.Application.Contract.Contacts;
using ReadModel.Application.Contract.Contacts.Dto;

namespace ReadModel.Facade.Contacts
{
    public interface IContactsQueryFacade
    {
        Task<List<ContactDto>> GetAllContractsAsync(GetAllContactsQuery query);
    }
}
