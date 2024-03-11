using ContactContext.Domain.Contacts.Services;

namespace ContactContext.Domain.Service.Contacts
{
    public class FirstNameLastNameDuplicationChecker : IFirstNameLastNameDuplicationChecker
    {
        private readonly IContactRepository contactRepository;

        public FirstNameLastNameDuplicationChecker(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }


        public bool IsDuplicate(string firstName, string lastName)
        {
            return contactRepository.Any(
                c => c.FirstName == firstName &&
                     c.LastName == lastName);
        }
    }


}
