using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Parsing;

public class Registro0000Parser
{
    public Registro0000 Parse(SpedLine line, Guid importacaoId, int numeroLinha)
    {
        return new Registro0000
        {
            Id = Guid.NewGuid(),
            ImportacaoId = importacaoId,
            NumeroLinha = numeroLinha,
            Reg = line.Get(1),
            CodVer = line.Get(2),
            CodFin = line.Get(3),
            DtIni = line.Get(4),
            DtFin = line.Get(5),
            Nome = line.Get(6),
            Cnpj = line.Get(7),
            Uf = line.Get(9),
            Ie = line.Get(10),
            LinhaOriginal = line.Raw
        };
    }
}