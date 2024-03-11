using ContactContext.Application.Contract.Contacts;
using ContactContext.Domain.Contacts.Services;
using Framework.Core.Application;

namespace ContactContext.Application.Contacts
{
    public class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand>
    {
        private readonly IPhoneNumberFormatChecker phoneNumberChecker;
        private readonly IContactRepository contactRepository;

        public UpdateContactCommandHandler(IPhoneNumberFormatChecker phoneNumberChecker,
            IContactRepository contactRepository)
        {
            this.phoneNumberChecker = phoneNumberChecker;
            this.contactRepository = contactRepository;
        }
        public Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = contactRepository.GeFirstNameLastName(request.FirstName,request.LastName);

            contact.SetPhones(phoneNumberChecker,request.Phones);

            return Task.CompletedTask;
        }
    }
}
