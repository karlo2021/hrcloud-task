// IPersonDatabaseContext.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Domain;

namespace Business.Infrastructure;

public interface IPersonDatabaseContext
{
    public DbSet<Person> Persons { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
