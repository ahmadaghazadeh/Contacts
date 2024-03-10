using Framework.Core.Domain;
using Framework.Domain;

namespace ContactContext.Domain
{
    public class Contact: EntityBase<Guid>, IAggregateRoot<Contact>
    {
    }
}
