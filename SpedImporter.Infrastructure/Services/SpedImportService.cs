using Microsoft.EntityFrameworkCore;
using SpedImporter.Application.Interfaces;
using SpedImporter.Domain.Entities;
using SpedImporter.Infrastructure.Data;
using SpedImporter.Infrastructure.Parsing;

namespace SpedImporter.Infrastructure.Services;

public class SpedImportService : ISpedImportService
{
    private readonly IFileReader _fileReader;
    private readonly AppDbContext _dbContext;

    public SpedImportService(IFileReader fileReader, AppDbContext dbContext)
    {
        _fileReader = fileReader;
        _dbContext  = dbContext;
    }

    public async Task<Guid> ImportAsync(string filePath, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Arquivo não encontrado.", filePath);

        var importacao = new Importacao
        {
            Id                = Guid.NewGuid(),
            NomeArquivo       = Path.GetFileName(filePath),
            DataImportacaoUtc = DateTime.UtcNow,
            Status            = "Processando"
        };

        _dbContext.Importacoes.Add(importacao);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var lineNumber = 0;
        var pending    = 0;
        const int batchSize = 500;

        //Parsers 
        var parser0000 = new Registro0000Parser();
        var parser0005 = new Registro0005Parser();
        var parser0100 = new Registro0100Parser();
        var parserE100  = new RegistroE100Parser();
        var parserE110  = new RegistroE110Parser();
        var parser1010  = new Registro1010Parser();

        // Versões suportadas 
        var versoesSuportadas = new[] { "015", "016", "017", "018", "019", "020" };

        await foreach (var rawLine in _fileReader.ReadLinesAsync(filePath, cancellationToken))
        {
            lineNumber++;

            if (string.IsNullOrWhiteSpace(rawLine))
                continue;

            var spedLine = new SpedLine(rawLine);

            string? erro     = null;
            var processado   = true;
            var codigoRegistro = spedLine.GetRegistroSeguro();

            // Validação de código inválido
            if (codigoRegistro == "INVALIDO")
            {
                erro       = "Código de registro inválido ou maior que 10 caracteres.";
                processado = false;
            }

            //Validação da primeira linha
            if (lineNumber == 1)
            {
                if (codigoRegistro != "0000")
                    throw new InvalidOperationException("A primeira linha deve ser o registro 0000.");

                importacao.VersaoLeiaute  = spedLine.Get(2);
                importacao.PeriodoInicial = spedLine.Get(4);
                importacao.PeriodoFinal   = spedLine.Get(5);

                if (!versoesSuportadas.Contains(importacao.VersaoLeiaute))
                {
                    erro = $"Versão de leiaute não suportada: '{importacao.VersaoLeiaute}'. " +
                           $"Versões aceitas: {string.Join(", ", versoesSuportadas)}.";
                    processado = false;
                }
            }

            // Parsers estruturados
            if (codigoRegistro == "0000")
            {
                var r = parser0000.Parse(spedLine, importacao.Id, lineNumber);
                _dbContext.Registros0000.Add(r);
            }
            else if (codigoRegistro == "0005")
            {
                var r = parser0005.Parse(spedLine, importacao.Id, lineNumber);
                _dbContext.Registros0005.Add(r);
            }
            else if (codigoRegistro == "0100")
            {
                var r = parser0100.Parse(spedLine, importacao.Id, lineNumber);
                _dbContext.Registros0100.Add(r);
            }
            else if (codigoRegistro == "E100")
            {
                var r = parserE100.Parse(spedLine, importacao.Id, lineNumber);
                _dbContext.RegistrosE100.Add(r);
            }
            else if (codigoRegistro == "E110")
            {
                var r = parserE110.Parse(spedLine, importacao.Id, lineNumber);
                _dbContext.RegistrosE110.Add(r);
            }
            else if (codigoRegistro =="1010")
            {
                var r = parser1010.Parse(spedLine, importacao.Id, lineNumber);
                _dbContext.Registros1010.Add(r);
            }

            //Staging (sempre salvo para rastreabilidade)
            var registroBruto = new RegistroBruto
            {
                Id               = Guid.NewGuid(),
                ImportacaoId     = importacao.Id,
                NumeroLinha      = lineNumber,
                CodigoRegistro   = codigoRegistro,
                LinhaOriginal    = rawLine,
                QuantidadeCampos = spedLine.BusinessFieldCount(),
                Processado       = processado,
                Erro             = erro
            };

            _dbContext.RegistrosBrutos.Add(registroBruto);
            pending++;

            if (pending >= batchSize)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
                pending = 0;
            }
        }

        if (pending > 0)
            await _dbContext.SaveChangesAsync(cancellationToken);

        importacao.TotalLinhas = lineNumber;

        var possuiAviso = await _dbContext.RegistrosBrutos
            .AnyAsync(x => x.ImportacaoId == importacao.Id && !x.Processado, cancellationToken);

        importacao.Status = possuiAviso ? "ConcluidoComAvisos" : "Concluido";

        await _dbContext.SaveChangesAsync(cancellationToken);

        return importacao.Id;
    }
}
