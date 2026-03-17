using System;
using System.Collections.Generic;
using System.Text;

using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Parsing;

public class Registro1010Parser
{
    public Registro1010 Parse(SpedLine line, Guid importacaoId, int numeroLinha)
    {
        return new Registro1010
        {
            Id = Guid.NewGuid(),
            ImportacaoId = importacaoId,
            NumeroLinha = numeroLinha,
            Reg = line.Get(1),
            IndExp = line.Get(2),
            IndCcrf = line.Get(3),
            IndComb = line.Get(4),
            IndUsina = line.Get(5),
            IndVa = line.Get(6),
            IndEe = line.Get(7),
            IndCart = line.Get(8),
            IndForm = line.Get(9),
            IndAer = line.Get(10),
            IndGiaf1 = line.Get(11),
            IndGiaf3 = line.Get(12),
            IndGiaf4 = line.Get(13),
            IndRestRessarcComplIcms = line.Get(14),
            LinhaOriginal = line.Raw
        };
    }
}