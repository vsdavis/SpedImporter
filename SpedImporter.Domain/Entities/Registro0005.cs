namespace SpedImporter.Domain.Entities;

/// <summary>
/// Registro 0005 — Dados Complementares do Estabelecimento
/// Exemplo: |0005|TOTAL EXPRESS|30810000|FLOR DAS PEDRAS|175|ANEXO PARTE I|JARDIM ALVORADA||||
/// </summary>
public class Registro0005
{
    public Guid Id { get; set; }
    public Guid ImportacaoId { get; set; }
    public int NumeroLinha { get; set; }

    /// <summary>Campo 01 — Texto fixo "0005"</summary>
    public string Reg { get; set; } = string.Empty;

    /// <summary>Campo 02 — Nome fantasia do estabelecimento</summary>
    public string? Fantasia { get; set; }

    /// <summary>Campo 03 — CEP</summary>
    public string? Cep { get; set; }

    /// <summary>Campo 04 — Logradouro (nome da rua/avenida)</summary>
    public string? Logr { get; set; }

    /// <summary>Campo 05 — Número do endereço</summary>
    public string? Num { get; set; }

    /// <summary>Campo 06 — Complemento do endereço</summary>
    public string? Compl { get; set; }

    /// <summary>Campo 07 — Bairro</summary>
    public string? Bairro { get; set; }

    /// <summary>Campo 08 — Telefone</summary>
    public string? Fone { get; set; }

    /// <summary>Campo 09 — Fax</summary>
    public string? Fax { get; set; }

    /// <summary>Campo 10 — E-mail do estabelecimento</summary>
    public string? Email { get; set; }

    /// <summary>Linha original preservada para rastreabilidade</summary>
    public string LinhaOriginal { get; set; } = string.Empty;

    public Importacao Importacao { get; set; } = null!;
}
