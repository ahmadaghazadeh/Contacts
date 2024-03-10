using ContactContext.Domain.Contacts.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;

namespace ContactContext.Domain.Contacts
{
    public class Contact : EntityBase<Guid>, IAggregateRoot<Contact>
    {
        public Contact(string firstName)
        {
            SetFirstName(firstName);
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new FirstNameInvalidFormatException();
        }
    }
}
