namespace SpedImporter.Application.Interfaces;

public interface ISpedImportService
{
    Task<Guid> ImportAsync(string filePath, CancellationToken cancellationToken = default);
}