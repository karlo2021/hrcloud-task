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
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        _ = app.UseMiddleware<ExceptionMiddleware>();
        _ = app.UseRouting();

        app.UseStaticFiles(new StaticFileOptions()
        {
            OnPrepareResponse = (context) =>
            {
                context.Context.Response.Headers["Cache-Control"] =
                    _configuration["StaticFiles:Headers:Cache-Control"];
                context.Context.Response.Headers["Pragma"] =
                    _configuration["StaticFiles:Headers:Pragma"];
                context.Context.Response.Headers["Expires"] =
                    _configuration["StaticFiles:Headers:Expires"];
            }
        });

        _ = app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
