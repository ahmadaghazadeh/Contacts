using ContactContext.Resource;
using Framework.Domain;

namespace ContactContext.Domain.Contacts.Exceptions;

public class LastNameInvalidFormatException : DomainException
{
    public override string Message => ExceptionResource.LastNameInvalidFormatException;
}