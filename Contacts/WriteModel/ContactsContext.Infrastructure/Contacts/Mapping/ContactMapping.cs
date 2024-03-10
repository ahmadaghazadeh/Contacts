using ContactContext.Domain.Contacts;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace ContactsContext.Infrastructure.Contacts.Mapping
{
    public class CustomerMapping : EntityMappingBase<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            Initialise(builder);
            builder.Property(c => c.FirstName).IsRequired();

            builder.Property(c => c.LastName).IsRequired();

            builder.Property(c => c.Phones)
                .HasConversion(new ValueConverter<List<string>, string>(
                    v => JsonConvert.SerializeObject(v), // Convert to string for persistence
                    v => JsonConvert.DeserializeObject<List<string>>(v))); // C

            builder.HasIndex(e => new { e.FirstName, e.LastName }).IsUnique();

        }
    }
}
