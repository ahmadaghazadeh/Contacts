using ContactContext.Resource;
using Framework.Domain;

namespace ContactContext.Domain.Contacts.Exceptions;

public class FirstNameLastNameDuplicatedException : DomainException
{
    public override string Message => ExceptionResource.FirstNameLastNameDuplicatedException;
}