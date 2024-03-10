using ContactContext.Resource;
using Framework.Domain;

namespace ContactContext.Domain.Contacts.Exceptions;

public class PhoneNumberInvalidFormatException : DomainException
{
    public override string Message => ExceptionResource.PhoneNumberInvalidFormatException;
}