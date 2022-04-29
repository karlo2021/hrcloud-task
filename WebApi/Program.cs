// Program.cs
//
// © 2021

namespace WebApi;

internal static class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(configureOptions =>
            {
                var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;

                _ = configureOptions
                    .AddJsonFile(path: "appsettings.json", optional: false)
                    .AddJsonFile(path: $"appsettings.{environmentVariable}.json")
                    .AddEnvironmentVariables()
                    .Build();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                _ = webBuilder.UseStartup<Startup>();
                _ = webBuilder.ConfigureLogging(logging =>
                {
                    _ = logging.ClearProviders();
                    _ = logging.AddSimpleConsole();
                });
            });
}