
using MediatR;

namespace ReadModel.Application.Contract.Contacts
{
    public class GetAllContactsQuery : IRequest<List<ContactDto>>
    {
    }
}

 
