using ContactContext.Resource;
using Framework.Domain;

namespace ContactContext.Domain.Contacts.Exceptions;

public class PhoneTypeInvalidFormatException : DomainException
{
	public override string Message => ExceptionResource.PhoneTypeInvalidFormatException;
}