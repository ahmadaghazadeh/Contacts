using Framework.Core.Domain;

namespace Framework.Core.Persistence
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot<TAggregateRoot>, IEntityBase
    {
    }
}
