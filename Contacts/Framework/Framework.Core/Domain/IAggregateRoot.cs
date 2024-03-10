namespace Framework.Core.Domain
{
    public interface IAggregateRoot<TAggregateRoot> where TAggregateRoot : class, IEntityBase
    {

    }
}
