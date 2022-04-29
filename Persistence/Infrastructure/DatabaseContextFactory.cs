// DatabaseContextFactory.cs
//
// © 2021

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Infrastructure;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    private static readonly ILoggerFactory s_loggerFactory = LoggerFactory.Create(options =>
    {
        options.AddConsole();
    });
    public DatabaseContext CreateDbContext(string[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Connection string must be provided through arguments!");
        }

        var connectionString = args[0];

        var configureOptions = new DbContextOptionsBuilder<DatabaseContext>();
        configureOptions.UseSqlServer(connectionString);
        configureOptions.UseLoggerFactory(s_loggerFactory);
        configureOptions.EnableDetailedErrors();

        return new DatabaseContext(configureOptions.Options);
    }
}
