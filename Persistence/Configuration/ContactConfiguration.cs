// ContactConfiguration.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;

namespace Persistence.Configuration;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(contact => contact.Number).HasMaxLength(Contact.MaxNumberLength);

        builder.HasIndex(contact => contact.Id).IsUnique();
    }
}
