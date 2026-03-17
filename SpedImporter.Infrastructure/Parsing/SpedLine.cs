namespace SpedImporter.Infrastructure.Parsing;

public sealed class SpedLine
{
    public string Raw { get; }
    public string[] Fields { get; }
    public string Registro => Get(1);

    public SpedLine(string raw)
    {
        Raw = (raw ?? string.Empty)
            .Trim()
            .TrimStart('\uFEFF');

        Fields = Raw.Split('|', StringSplitOptions.None);
    }

    public string Get(int index)
    {
        if (index < 0 || index >= Fields.Length)
            return string.Empty;

        return (Fields[index] ?? string.Empty).Trim();
    }

    public string GetRegistroSeguro()
    {
        var registro = Get(1);

        if (string.IsNullOrWhiteSpace(registro))
            return "INVALIDO";

        if (registro.Length > 10)
            return "INVALIDO";

        return registro;
    }

    public int BusinessFieldCount()
    {
        if (Fields.Length < 2)
            return 0;

        var count = Fields.Length;

        if (Fields[0] == string.Empty)
            count--;

        if (Fields[^1] == string.Empty)
            count--;

        return count;
    }
}