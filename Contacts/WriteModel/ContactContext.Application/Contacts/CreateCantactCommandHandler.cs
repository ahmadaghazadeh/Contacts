
using ContactContext.Application.Contract.Contacts;
using ContactContext.Domain.Contacts;
using ContactContext.Domain.Contacts.Services;
using Framework.Core.Application;

namespace ContactContext.Application.Contacts
{
    public class CreateContactCommandHandler : ICommandHandler<CreateContactCommand>
    {
        private readonly IPhoneNumberFormatChecker phoneNumberChecker;
        private readonly IFirstNameLastNameDuplicationChecker firstNameLastNameDuplicationChecker;
        private readonly IContactRepository contactRepository;

        public CreateContactCommandHandler(IPhoneNumberFormatChecker phoneNumberChecker,
            IFirstNameLastNameDuplicationChecker firstNameLastNameDuplicationChecker,
            IContactRepository contactRepository)
        {
            this.phoneNumberChecker = phoneNumberChecker;
            this.firstNameLastNameDuplicationChecker = firstNameLastNameDuplicationChecker;
            this.contactRepository = contactRepository;
        }
        public Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var customer = new Contact(
                phoneNumberChecker,
                firstNameLastNameDuplicationChecker,
                request.FirstName,
                request.LastName,
                request.Phones) ;

            contactRepository.Create(customer);

            return Task.CompletedTask;
        }
    }
}
