using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Parsing;

public class Registro0000Parser // Esta classe é responsável por analisar uma linha do arquivo SPED e criar um objeto Registro0000 a partir dos dados contidos nessa linha.
                                // O método Parse recebe uma linha do arquivo SPED, um identificador de importação e o número da linha, e retorna um objeto
                                // Registro0000 preenchido com os dados extraídos da linha.
{
    public Registro0000 Parse(SpedLine line, Guid importacaoId, int numeroLinha)
    {
        return new Registro0000
        {
            Id = Guid.NewGuid(),
            ImportacaoId = importacaoId,
            NumeroLinha = numeroLinha,
            Reg = line.Get(1),
            CodVer = line.Get(2),
            CodFin = line.Get(3),
            DtIni = line.Get(4),
            DtFin = line.Get(5),
            Nome = line.Get(6),
            Cnpj = line.Get(7),
            Uf = line.Get(9),
            Ie = line.Get(10),
            LinhaOriginal = line.Raw
        };
    }
    // O registro 0000 é o registro de abertura do arquivo SPED, e contém informações básicas sobre a empresa e o período de apuração dos dados contidos no arquivo.
}