using System;
using System.Collections.Generic;
using System.Text;

namespace SpedImporter.Domain.Entities;
/// Registro E100 — Período de Apuração do ICMS
/// Exemplo: |E100|01012021|31012021|

public class RegistroE100
{
    public Guid Id { get; set; }
    public Guid ImportacaoId { get; set; }
    public int NumeroLinha { get; set; }

    ///Campo 01 — Texto fixo "E100"
    public string Reg { get; set; } = string.Empty;

    ///>Campo 02 — Data de início do período de apuração (DDMMAAAA)
    public string? DtIni { get; set; }

    ///Campo 03 — Data de fim do período de apuração (DDMMAAAA)
    public string? DtFin { get; set; }

    ///Linha original preservada para rastreabilidade
    public string LinhaOriginal { get; set; } = string.Empty;

    public Importacao Importacao { get; set; } = null!;
}