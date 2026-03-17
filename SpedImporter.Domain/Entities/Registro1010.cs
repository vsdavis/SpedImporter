using System;
using System.Collections.Generic;
using System.Text;

namespace SpedImporter.Domain.Entities;

/// Registro 1010 — Obrigatoriedade de Registros do Bloco 1
/// Exemplo: |1010|N|N|N|N|N|N|N|N|N|N|N|N|N|
/// Cada campo é um indicador S/N informando se a empresa possui aquela obrigação.
public class Registro1010
{
    public Guid Id { get; set; }
    public Guid ImportacaoId { get; set; }
    public int NumeroLinha { get; set; }

    ///  Campo 01 — Texto fixo "1010"
    public string Reg { get; set; } = string.Empty;

    ///  Campo 02 — Possui operações com exportação? (S/N)
    public string? IndExp { get; set; }

    ///  Campo 03 — Possui operações com CCRF? (S/N) 
    public string? IndCcrf { get; set; }

    ///  Campo 04 — Possui operações com combustíveis? (S/N)
    public string? IndComb { get; set; }

    ///  Campo 05 — Possui operações com usina de açúcar/álcool? (S/N)
    public string? IndUsina { get; set; }

    ///  Campo 06 — Possui operações com veículos automotores (VA)? (S/N)
    public string? IndVa { get; set; }

    ///  Campo 07 — Possui operações com energia elétrica? (S/N)
    public string? IndEe { get; set; }

    ///  Campo 08 — Possui operações com cartão de crédito/débito? (S/N)
    public string? IndCart { get; set; }

    ///  Campo 09 — Possui operações com formulário de segurança? (S/N)
    public string? IndForm { get; set; }

    ///  Campo 10 — Possui operações com transporte aéreo? (S/N)
    public string? IndAer { get; set; }

    ///  Campo 11 — Possui informações para GIAF1? (S/N)
    public string? IndGiaf1 { get; set; }

    ///  Campo 12 — Possui informações para GIAF3? (S/N)
    public string? IndGiaf3 { get; set; }

    ///  Campo 13 — Possui informações para GIAF4? (S/N)
    public string? IndGiaf4 { get; set; }

    ///  Campo 14 — Possui restituição/ressarcimento/complementação de ICMS? (S/N)
    public string? IndRestRessarcComplIcms { get; set; }

    ///  Linha original preservada para rastreabilidade
    public string LinhaOriginal { get; set; } = string.Empty;

    public Importacao Importacao { get; set; } = null!;
}