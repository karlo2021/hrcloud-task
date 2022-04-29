// DatabaseContext.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Business.Infrastructure;
using Domain;
using Persistence.Configuration;

namespace Persistence;
public class DatabaseContext
    : DbContext, IPersonDatabaseContext, IContactDatabaseContext, IEmailAddressDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<EmailAddress> EmailAddresses { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new PersonConfiguration());
        builder.ApplyConfiguration(new ContactConfiguration());
        builder.ApplyConfiguration(new EmailAddressConfiguration());
    }
}
