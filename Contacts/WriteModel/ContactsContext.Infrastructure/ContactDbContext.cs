using System.ComponentModel;
using ContactContext.Domain.Contacts;
using ContactsContext.Infrastructure.Contacts.Mapping;
using Framework.Core.Domain;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ContactsContext.Infrastructure
{
    public class ContactDbContext : DbContextBase
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RegisterAllEntities<IEntityBase>(typeof(Contact).Assembly);
            modelBuilder.RegisterEntityMappings(typeof(CustomerMapping).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            configurationBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>();
        }
    }
}
