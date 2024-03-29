﻿
using ContactContext.Domain.Contacts;
using ContactContext.Domain.Contacts.Services;
using Framework.Core.Persistence;
using Framework.Persistence;
using System.Linq;
using System.Linq.Expressions;

namespace ContactsContext.Infrastructure.Contacts
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Create(Contact contact)
        {
            base.Create(contact);
        }

        public Contact GetById(Guid id)
        {
            var contact = Set
                .Single(inc => inc.Id == id);
            return contact;
        }
        // This thing doesn't correct in the real business.
        public Contact GeFirstNameLastName(string firstName, string lastName)
        {
            var contact = Set
                .Single(inc => inc.FirstName == firstName && inc.LastName==lastName);
            return contact;
        }

        public void Delete(Contact contact)
        {
            base.Delete(contact);
        }

        public bool Any(Expression<Func<Contact, bool>> predicate)
        {
            return Set
                .Any(predicate);
        }
    }
}
