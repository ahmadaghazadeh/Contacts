using Framework.Core.Domain;

namespace ContactContext.Domain.Contacts.Services;

public interface IFirstNameLastNameDuplicationChecker : IDomainService
{
    bool IsDuplicate(string firstName,string lastName);
}