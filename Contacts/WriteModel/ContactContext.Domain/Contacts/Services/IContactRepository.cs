using Framework.Core.Persistence;
using System.Linq.Expressions;

namespace ContactContext.Domain.Contacts.Services
{
    public interface IContactRepository : IRepository<Contact>
    {
        void Create(Contact contact);

        Contact GetById(Guid id);

        // This thing doesn't correct in the real business.
        Contact GeFirstNameLastName(string firstName, string lastName);

        void Delete(Contact contact);

        bool Any(Expression<Func<Contact, bool>> predicate);
    }
}
