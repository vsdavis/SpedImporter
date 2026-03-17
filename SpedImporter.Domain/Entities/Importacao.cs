namespace SpedImporter.Domain.Entities;

public class Importacao
{
    public Guid Id { get; set; }
    public string NomeArquivo { get; set; } = string.Empty;
    public DateTime DataImportacaoUtc { get; set; }
    public string Status { get; set; } = "Pendente";
    public int TotalLinhas { get; set; }

    public string? VersaoLeiaute { get; set; }
    public string? PeriodoInicial { get; set; }
    public string? PeriodoFinal { get; set; }

    public ICollection<RegistroBruto> Registros { get; set; } = new List<RegistroBruto>();
}