using Framework.Core.Application;
using Microsoft.EntityFrameworkCore;
using ReadModel.Application.Contract.Contacts;
using ReadModel.Infrastructure.Models;

namespace ReadModel.Application.Customers
{
    public class GetAllContactsQueryHandler : IQueryHandler<GetAllContactsQuery, List<ContactDto>>
    {

        private readonly ContactReadDbContext context;

        public GetAllContactsQueryHandler(ContactReadDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            //var query = context.Contacts;
            //return await query.Select(a => new ContactDto()
            //{
            //    FirstName = a.FirstName,
            //    LastName = a.LastName,
            //}).ToListAsync(cancellationToken: cancellationToken);
            return null;
        }
    }
}
