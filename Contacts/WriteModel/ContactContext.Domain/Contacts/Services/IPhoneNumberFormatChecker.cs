
using Framework.Core.Domain;

namespace ContactContext.Domain.Contacts.Services
{
    public interface IPhoneNumberFormatChecker : IDomainService
    {
        bool Check(string phoneNumber);
    }
}
