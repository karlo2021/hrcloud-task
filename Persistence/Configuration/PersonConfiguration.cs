// PersonConfiguration.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;

namespace Persistence.Configuration;
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(person => person.FirstName).HasMaxLength(Person.MaxStringLength);
        builder.Property(person => person.LastName).HasMaxLength(Person.MaxStringLength);
        builder.Property(person => person.Address).HasMaxLength(Person.MaxStringLength);

        builder.HasIndex(person => person.Id).IsUnique();
    }
}
