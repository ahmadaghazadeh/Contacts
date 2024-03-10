using Framework.Core.Domain;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Persistence
{
    public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntityBase
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        protected void Initialise(EntityTypeBuilder<TEntity> builder, bool isTemporal = false, bool isUserTracking = false)
        {
            var a = typeof(TEntity);

            var entityType = typeof(EntityBase<>).Name;


            if (a.BaseType != null && a.BaseType.Name == entityType && a is { IsClass: true, IsAbstract: false })
            {
                builder.HasKey("Id");
                builder.Property("Id")
                    .ValueGeneratedNever();
            }
            ToTable(builder);

        }

        protected void ToTable(EntityTypeBuilder<TEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable(typeof(TEntity).Name, typeof(TEntity).Namespace?.Split('.')[1]);
        }
    }
}
