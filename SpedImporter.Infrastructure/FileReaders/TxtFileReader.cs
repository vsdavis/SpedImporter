using System.Runtime.CompilerServices;
using System.Text;
using SpedImporter.Application.Interfaces;

namespace SpedImporter.Infrastructure.FileReaders;

public class TxtFileReader : IFileReader
{
    public async IAsyncEnumerable<string> ReadLinesAsync(
        string path,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-1"));

        while (!reader.EndOfStream)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var line = await reader.ReadLineAsync();
            if (line is not null)
            {
                yield return line;
            }
        }
    }
}