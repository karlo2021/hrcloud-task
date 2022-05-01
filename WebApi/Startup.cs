// Startup.cs
//
// © 2021

using Microsoft.EntityFrameworkCore;

using Business.Infrastructure;
using Business.Services.Abstraction;
using Business.Services.Implementation;
using Persistence;
using WebApi.Infrastructure;

namespace WebApi;

internal sealed partial class Startup
{
    public readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection service)
    {
        service.AddScoped<IPersonService, PersonService>();
        service.AddScoped<IPersonValidationService, PersonValidationService>();
        service.AddDbContext<IPersonDatabaseContext, DatabaseContext>(dbContextOptionsBuilder =>
        {
            _ = dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalDatabase"));
        });

        service.AddScoped<IContactService, ContactService>();
        service.AddScoped<IContactValidationService, ContactValidationService>();
        service.AddDbContext<IContactDatabaseContext, DatabaseContext>(dbContextOptionsBuilder =>
        {
            _ = dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalDatabase"));
        });

        service.AddScoped<IEmailAddressService, EmailAddressService>();
        service.AddScoped<IEmailAddressValidationService, EmailAddressValidationService>();
        service.AddDbContext<IEmailAddressDatabaseContext, DatabaseContext>(dbContextOptionsBuilder =>
        {
            _ = dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalDatabase"));
        });

        service.AddScoped<IPersonViewService, PersonViewService>();
        service.AddControllers();
    }
    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        _ = app.UseMiddleware<ExceptionMiddleware>();
        _ = app.UseRouting();

        _ = app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
