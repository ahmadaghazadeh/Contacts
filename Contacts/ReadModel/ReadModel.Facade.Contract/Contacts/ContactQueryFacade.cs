using Framework.Core.Facade;
using MediatR;
using ReadModel.Application.Contract.Contacts;
using ReadModel.Application.Contract.Contacts.Dto;
using ReadModel.Facade.Contacts;

namespace ReadModel.Facade.Contract.Contacts
{
    public class ContactQueryFacade : FacadeQueryBase, IContactsQueryFacade
	{
        public ContactQueryFacade(IMediator mediator) : base(mediator)
        {
        }

        public Task<List<ContactDto>> GetAllContractsAsync(GetAllContactsQuery query)
        {
			return Mediator.Send(query);
		}
	}
}
