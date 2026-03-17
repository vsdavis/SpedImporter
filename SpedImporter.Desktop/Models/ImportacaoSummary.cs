namespace SpedImporter.Desktop.Models;

public class ImportacaoSummary
{
    public Guid Id { get; set; }
    public string Arquivo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Linhas { get; set; }
    public string Leiaute { get; set; } = "-";
    public string Periodo { get; set; } = "-";
    public int Avisos { get; set; }
}
