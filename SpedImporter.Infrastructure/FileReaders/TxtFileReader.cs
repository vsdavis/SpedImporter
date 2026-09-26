using System.Runtime.CompilerServices;
using System.Text;
using SpedImporter.Application.Interfaces;

namespace SpedImporter.Infrastructure.FileReaders;

public class TxtFileReader : IFileReader // Esta classe implementa a interface IFileReader, que define um contrato para leitura de arquivos.
{
    public async IAsyncEnumerable<string> ReadLinesAsync(
        string path,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-1")); // O StreamReader é usado para ler o conteúdo do arquivo de texto, e a codificação "iso-8859-1"
                                                                                         // é especificada para garantir que os caracteres sejam interpretados corretamente.

        while (!reader.EndOfStream)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var line = await reader.ReadLineAsync();
            if (line is not null) // Usarei o yield, pois ele é um recurso do C# que permite criar um método iterador, que pode retornar
                                  // uma sequência de valores um de cada vez, em vez de retornar todos os valores de uma vez.

            {
                yield return line; 
                // yield esta linha para o consumidor do IAsyncEnumerable 
                // O yield return é usado para retornar cada linha lida do arquivo de forma assíncrona, permitindo que 
                //o consumidor processe as linhas à medida que são lidas, sem precisar esperar o arquivo inteiro ser carregado na memória.
            }
        }
    }
}