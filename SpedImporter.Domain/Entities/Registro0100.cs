namespace SpedImporter.Domain.Entities;

/// <summary>
/// Registro 0100 — Dados do Contabilista
/// Exemplo abaixo utiliza dados inteiramente fictícios para fins de teste.
/// Exemplo: |0100|ANDREIA LOBATO DE OLIVEIRA SILVA|29778618828|1SP253708||06046003|AV PIRACEMA|155|GALPAO 01|SITIO TAMBORE|01136275900||cpfiscal@totalexpress.com.br|3505708|
/// </summary>
public class Registro0100
{
    public Guid Id { get; set; }
    public Guid ImportacaoId { get; set; }
    public int NumeroLinha { get; set; }

    /// <summary>Campo 01 — Texto fixo "0100"</summary>
    public string Reg { get; set; } = string.Empty;

    /// <summary>Campo 02 — Nome completo do contabilista</summary>
    public string? Nome { get; set; }

    /// <summary>Campo 03 — CPF do contabilista</summary>
    public string? Cpf { get; set; }

    /// <summary>Campo 04 — CRC (Conselho Regional de Contabilidade)</summary>
    public string? Crc { get; set; }

    /// <summary>Campo 05 — CNPJ do escritório de contabilidade (pode ser vazio)</summary>
    public string? CnpjEsc { get; set; }

    /// <summary>Campo 06 — CEP do contabilista</summary>
    public string? Cep { get; set; }

    /// <summary>Campo 07 — Logradouro</summary>
    public string? Logr { get; set; }

    /// <summary>Campo 08 — Número do endereço</summary>
    public string? Num { get; set; }

    /// <summary>Campo 09 — Complemento do endereço</summary>
    public string? Compl { get; set; }

    /// <summary>Campo 10 — Bairro</summary>
    public string? Bairro { get; set; }

    /// <summary>Campo 11 — Telefone</summary>
    public string? Fone { get; set; }

    /// <summary>Campo 12 — Fax</summary>
    public string? Fax { get; set; }

    /// <summary>Campo 13 — E-mail do contabilista</summary>
    public string? Email { get; set; }

    /// <summary>Campo 14 — Código do município (IBGE)</summary>
    public string? CodMun { get; set; }

    /// <summary>Linha original preservada para rastreabilidade</summary>
    public string LinhaOriginal { get; set; } = string.Empty;

    public Importacao Importacao { get; set; } = null!;
}
