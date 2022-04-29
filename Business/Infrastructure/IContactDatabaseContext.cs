// IContactDatabaseContext.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Domain;

namespace Business.Infrastructure;

public interface IContactDatabaseContext
{
    public DbSet<Contact> Contacts { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
