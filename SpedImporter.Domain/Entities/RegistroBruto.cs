namespace SpedImporter.Domain.Entities;

public class RegistroBruto
{
    public Guid Id { get; set; }
    public Guid ImportacaoId { get; set; }
    public Importacao Importacao { get; set; } = null!;

    public int NumeroLinha { get; set; }
    public string CodigoRegistro { get; set; } = string.Empty;
    public string LinhaOriginal { get; set; } = string.Empty;
    public int QuantidadeCampos { get; set; }

    public bool Processado { get; set; }
    public string? Erro { get; set; }
}