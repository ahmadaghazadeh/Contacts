using ContactContext.Domain.Contacts.Exceptions;
using ContactContext.Domain.Contacts.Services;
using Framework.Core.Domain;
using Framework.Domain;

namespace ContactContext.Domain.Contacts
{
    public class Contact : EntityBase<Guid>, IAggregateRoot<Contact>
    {
        public Contact(IPhoneNumberFormatChecker phoneChecker,
            IFirstNameLastNameDuplicationChecker firstNameLastNameDuplicationChecker,
            string firstName,
            string lastName,
            List<string> phones)
        {

            if (firstNameLastNameDuplicationChecker.IsDuplicate(firstName, lastName))
                throw new FirstNameLastNameDuplicatedException();

            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhones(phoneChecker,phones);
        }
        protected Contact(){}


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Phones { get; set; }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new FirstNameInvalidFormatException();

            this.FirstName = firstName;
        }
        private void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new LastNameInvalidFormatException();

            this.LastName = lastName;
        }

        private void SetPhones(IPhoneNumberFormatChecker checker,List<string> phones)
        {
            foreach (var phone in phones)
            {
                if (!checker.Check(phone))
                    throw new PhoneNumberInvalidFormatException();
            }

            this.Phones = phones;
        }

    }
}
