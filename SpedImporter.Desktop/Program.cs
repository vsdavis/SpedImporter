using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpedImporter.Application.Interfaces;
using SpedImporter.Infrastructure.Data;
using SpedImporter.Infrastructure.FileReaders;
using SpedImporter.Infrastructure.Services;
using SpedImporter.Desktop;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        using var host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var dbContext = services.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();

            var mainForm = services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Falha ao iniciar a aplicação.\n\n{ex.Message}",
                "SPED Importer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("MySql")
                    ?? throw new InvalidOperationException("Connection string 'MySql' não encontrada.");

                services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                services.AddScoped<IFileReader, TxtFileReader>();
                services.AddScoped<ISpedImportService, SpedImportService>();
                services.AddTransient<MainForm>();
            });
    }
}
