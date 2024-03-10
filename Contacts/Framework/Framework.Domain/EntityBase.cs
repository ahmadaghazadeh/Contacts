using Framework.Core.Domain;

namespace Framework.Domain
{
    public abstract class EntityBase<Tkey> : IEntityBase
    {
        public Tkey Id { get; protected set; }
        protected EntityBase() { }
        protected EntityBase(Tkey id)
        {
            Id = id;
        }
    }
}
