using System;
using System.Collections.Generic;
using System.Text;
using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Parsing;

public class RegistroE100Parser
{
    public RegistroE100 Parse(SpedLine line, Guid importacaoId, int numeroLinha)
    {
        return new RegistroE100
        {
            Id = Guid.NewGuid(),
            ImportacaoId = importacaoId,
            NumeroLinha = numeroLinha,
            Reg = line.Get(1),
            DtIni = line.Get(2),
            DtFin = line.Get(3),
            LinhaOriginal = line.Raw
        };
    }
}