using ContactContext.Domain.Contacts;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace ContactsContext.Infrastructure.Contacts.Mapping
{
    public class ContactMapping : EntityMappingBase<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            Initialise(builder);
            builder.Property(c => c.FirstName).IsRequired();

            builder.Property(c => c.LastName).IsRequired();

            builder.OwnsMany(c => c.Phones, p =>
            {
	            p.Property(p1 => p1.Number);
	            p.Property(p1 => p1.Type);
			});

			builder.HasIndex(e => new { e.FirstName, e.LastName }).IsUnique();

        }
    }
}
