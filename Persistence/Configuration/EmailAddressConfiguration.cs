// EmailAddressConfiguration.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;

namespace Persistence.Configuration;

public class EmailAddressConfiguration : IEntityTypeConfiguration<EmailAddress>
{
    public void Configure(EntityTypeBuilder<EmailAddress> builder)
    {
        builder.Property(email => email.Email).HasMaxLength(EmailAddress.MaxEmailLength);

        builder.HasIndex(email => email.Id).IsUnique();
    }
}
