using ContactContext.Resource;
using Framework.Domain;

namespace ContactContext.Domain.Contacts.Exceptions;

public class PhoneNumberDuplicateException : DomainException
{
	public override string Message => ExceptionResource.PhoneNumberDuplicateException;
}