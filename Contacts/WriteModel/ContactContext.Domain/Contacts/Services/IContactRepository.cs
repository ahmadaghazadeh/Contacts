using Framework.Core.Persistence;
using System.Linq.Expressions;

namespace ContactContext.Domain.Contacts.Services
{
    public interface IContactRepository : IRepository<Contact>
    {
        void Create(Contact contact);

        Contact GetById(Guid id);

        void Delete(Contact contact);

        bool Any(Expression<Func<Contact, bool>> predicate);
    }
}
