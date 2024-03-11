using ContactContext.Application.Contract.Contacts;
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
            List<PhoneDto> phones) : base(Guid.NewGuid())
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
        public List<Phone> Phones { get; set; }

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

        public void SetPhones(IPhoneNumberFormatChecker checker,List<PhoneDto> phones)
        {
	        var isDuplicated = phones.GroupBy(x => x.Number)
		        .Where(group => group.Count() > 1)
		        .Select(group => group.Key);

	        if (isDuplicated.Any())
		        throw new PhoneNumberDuplicateException();

	        var phonesList = phones.Select(p => new Phone(checker,p.Type, p.Number)).ToList();

			this.Phones = phonesList;
        }

    }
}
