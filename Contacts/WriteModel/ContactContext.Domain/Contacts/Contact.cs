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

        public string FirstName { get; set; }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new FirstNameInvalidFormatException();

            this.FirstName = firstName;
        }

     
    }
}
