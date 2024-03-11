using ContactContext.Application.Contract.Contacts;
using ContactContext.Domain.Contacts.Services;
using Framework.Core.Application;

namespace ContactContext.Application.Contacts
{
    public class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand>
    {
        private readonly IContactRepository contactRepository;

        public DeleteContactCommandHandler(
            IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = contactRepository.GeFirstNameLastName(request.FirstName,request.LastName);

            contactRepository.Delete(contact);

            return Task.CompletedTask;
        }
    }
}
