using System;
using System.Collections.Generic;
using System.Text;
using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Parsing;

public class RegistroE110Parser
{
    public RegistroE110 Parse(SpedLine line, Guid importacaoId, int numeroLinha)
    {
        return new RegistroE110
        {
            Id = Guid.NewGuid(),
            ImportacaoId = importacaoId,
            NumeroLinha = numeroLinha,
            Reg = line.Get(1),
            VlTotDebitos = ParseDecimal(line.Get(2)),
            VlAjDebitos = ParseDecimal(line.Get(3)),
            VlTotAjDebitos = ParseDecimal(line.Get(4)),
            VlEstornosCreditos = ParseDecimal(line.Get(5)),
            VlTotCreditos = ParseDecimal(line.Get(6)),
            VlAjCreditos = ParseDecimal(line.Get(7)),
            VlTotAjCreditos = ParseDecimal(line.Get(8)),
            VlEstornosDebitos = ParseDecimal(line.Get(9)),
            VlSldCredorAnterior = ParseDecimal(line.Get(10)),
            VlSldApurado = ParseDecimal(line.Get(11)),
            VlTotDed = ParseDecimal(line.Get(12)),
            VlIcmsRecolher = ParseDecimal(line.Get(13)),
            VlSldCredorTransportar = ParseDecimal(line.Get(14)),
            VlDebEspecial = ParseDecimal(line.Get(15)),
            LinhaOriginal = line.Raw
        };
    }

    /// Converte string SPED para decimal.
    /// O SPED usa vírgula como separador decimal (ex: "1234,56").
    /// Retorna null se o campo for vazio ou inválido.
    private static decimal? ParseDecimal(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var normalized = value.Replace(",", ".");

        return decimal.TryParse(normalized,
            System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture,
            out var result) ? result : null;
    }
}