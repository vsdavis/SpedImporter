using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpedImporter.Application.Interfaces;
using SpedImporter.Infrastructure.Data;
using SpedImporter.Infrastructure.FileReaders;
using SpedImporter.Infrastructure.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
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
    })
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

var dbContext = services.GetRequiredService<AppDbContext>();
await dbContext.Database.MigrateAsync();

var importService = services.GetRequiredService<ISpedImportService>();

Console.WriteLine("Informe o caminho completo do arquivo TXT:");
var filePath = Console.ReadLine();

if (string.IsNullOrWhiteSpace(filePath))
{
    Console.WriteLine("Caminho não informado.");
    return;
}

try
{
    var importacaoId = await importService.ImportAsync(filePath);
    Console.WriteLine($"Importação concluída. Id: {importacaoId}");
}
catch (Exception ex)
{
    Console.WriteLine("Erro ao importar:");
    Console.WriteLine(ex.Message);
}