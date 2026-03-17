namespace SpedImporter.Domain.Entities;

public class Registro0000
{
    public Guid Id { get; set; }

    public Guid ImportacaoId { get; set; }
    public Importacao Importacao { get; set; } = null!;

    public int NumeroLinha { get; set; }

    public string Reg { get; set; } = string.Empty;
    public string CodVer { get; set; } = string.Empty;
    public string CodFin { get; set; } = string.Empty;
    public string DtIni { get; set; } = string.Empty;
    public string DtFin { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Uf { get; set; } = string.Empty;
    public string Ie { get; set; } = string.Empty;

    public string LinhaOriginal { get; set; } = string.Empty;
}