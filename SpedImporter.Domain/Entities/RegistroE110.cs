using System;
using System.Collections.Generic;
using System.Text;

namespace SpedImporter.Domain.Entities;

/// Registro E110 — Apuração do ICMS - Operações Próprias
/// Exemplo: |E110|0|0|0|0|0|0|0|0|0|0|0|0|0|0|
public class RegistroE110
{
    public Guid Id { get; set; }
    public Guid ImportacaoId { get; set; }
    public int NumeroLinha { get; set; }

    ///Campo 01 — Texto fixo "E110"
    public string Reg { get; set; } = string.Empty;

    ///Campo 02 — Valor total dos débitos por saídas e prestações com débito do imposto
    public decimal? VlTotDebitos { get; set; }

    ///Campo 03 — Valor total dos ajustes a débito decorrentes do documento fiscal
    public decimal? VlAjDebitos { get; set; }

    ///Campo 04 — Valor total dos ajustes a débito
    public decimal? VlTotAjDebitos { get; set; }

    ///Campo 05 — Valor total dos estornos de créditos
    public decimal? VlEstornosCreditos { get; set; }

    ///Campo 06 — Valor total dos créditos por entradas e aquisições com crédito do imposto
    public decimal? VlTotCreditos { get; set; }

    ///Campo 07 — Valor total dos ajustes a crédito decorrentes do documento fiscal
    public decimal? VlAjCreditos { get; set; }

    ///Campo 08 — Valor total dos ajustes a crédito
    public decimal? VlTotAjCreditos { get; set; }

    ///Campo 09 — Valor total dos estornos de débitos
    public decimal? VlEstornosDebitos { get; set; }

    ///Campo 10 — Valor do saldo credor do período anterior
    public decimal? VlSldCredorAnterior { get; set; }

    ///Campo 11 — Valor do saldo apurado (devedor ou credor)
    public decimal? VlSldApurado { get; set; }

    ///Campo 12 — Valor total das deduções
    public decimal? VlTotDed { get; set; }

    ///Campo 13 — Valor do ICMS a recolher
    public decimal? VlIcmsRecolher { get; set; }

    ///Campo 14 — Valor do saldo credor a transportar para o período seguinte
    public decimal? VlSldCredorTransportar { get; set; }

    ///Campo 15 — Valor dos débitos especiais
    public decimal? VlDebEspecial { get; set; }

    ///Linha original preservada para rastreabilidade
    public string LinhaOriginal { get; set; } = string.Empty;

    public Importacao Importacao { get; set; } = null!;
}