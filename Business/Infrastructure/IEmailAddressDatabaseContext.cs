// IEmailAddressDatabaseContext.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Domain;

namespace Business.Infrastructure;

public interface IEmailAddressDatabaseContext
{
    public DbSet<EmailAddress> EmailAddresses { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}
