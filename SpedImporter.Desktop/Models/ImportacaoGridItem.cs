namespace SpedImporter.Desktop.Models;

public class ImportacaoGridItem
{
    public Guid Id { get; set; }
    public string Arquivo { get; set; } = string.Empty;
    public DateTime DataImportacaoUtc { get; set; }
    public string Status { get; set; } = string.Empty;
    public int Linhas { get; set; }
    public string Leiaute { get; set; } = string.Empty;
    public int Avisos { get; set; }
}
