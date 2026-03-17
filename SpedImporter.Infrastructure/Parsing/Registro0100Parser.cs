using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Parsing;

public class Registro0100Parser
{
    public Registro0100 Parse(SpedLine line, Guid importacaoId, int numeroLinha)
    {
        return new Registro0100
        {
            Id           = Guid.NewGuid(),
            ImportacaoId = importacaoId,
            NumeroLinha  = numeroLinha,
            Reg          = line.Get(1),
            Nome         = line.Get(2),
            Cpf          = line.Get(3),
            Crc          = line.Get(4),
            CnpjEsc      = line.Get(5),
            Cep          = line.Get(6),
            Logr         = line.Get(7),
            Num          = line.Get(8),
            Compl        = line.Get(9),
            Bairro       = line.Get(10),
            Fone         = line.Get(11),
            Fax          = line.Get(12),
            Email        = line.Get(13),
            CodMun       = line.Get(14),
            LinhaOriginal = line.Raw
        };
    }
}
