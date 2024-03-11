using ContactContext.Domain.Contacts.Services;
using CustomerContext.Application.Contract.Customers;
using Framework.Core.Application;

namespace CustomerContext.Application.Customers
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
