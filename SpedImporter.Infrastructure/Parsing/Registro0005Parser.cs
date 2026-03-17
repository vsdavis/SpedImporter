using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Parsing;

public class Registro0005Parser
{
    public Registro0005 Parse(SpedLine line, Guid importacaoId, int numeroLinha)
    {
        return new Registro0005
        {
            Id           = Guid.NewGuid(),
            ImportacaoId = importacaoId,
            NumeroLinha  = numeroLinha,
            Reg          = line.Get(1),
            Fantasia     = line.Get(2),
            Cep          = line.Get(3),
            Logr         = line.Get(4),
            Num          = line.Get(5),
            Compl        = line.Get(6),
            Bairro       = line.Get(7),
            Fone         = line.Get(8),
            Fax          = line.Get(9),
            Email        = line.Get(10),
            LinhaOriginal = line.Raw
        };
    }
}
