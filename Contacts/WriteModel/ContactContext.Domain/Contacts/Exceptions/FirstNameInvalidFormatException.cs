using ContactContext.Resource;
using Framework.Domain;

namespace ContactContext.Domain.Contacts.Exceptions
{
    public class FirstNameInvalidFormatException : DomainException
    {
        public override string Message => ExceptionResource.FirstNameInvalidFormatException;
    }
}
