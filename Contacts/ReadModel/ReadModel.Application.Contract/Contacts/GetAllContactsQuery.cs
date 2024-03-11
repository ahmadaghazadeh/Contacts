
using MediatR;
using ReadModel.Application.Contract.Contacts.Dto;

namespace ReadModel.Application.Contract.Contacts
{
    public class GetAllContactsQuery : IRequest<List<ContactDto>>
    {
    }
}

 
