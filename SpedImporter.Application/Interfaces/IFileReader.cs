namespace SpedImporter.Application.Interfaces;

public interface IFileReader
{
    IAsyncEnumerable<string> ReadLinesAsync(
        string path,
        CancellationToken cancellationToken = default);
}