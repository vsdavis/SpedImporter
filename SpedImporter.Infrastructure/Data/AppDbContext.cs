using Microsoft.EntityFrameworkCore;
using SpedImporter.Domain.Entities;

namespace SpedImporter.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Importacao>    Importacoes     => Set<Importacao>();
    public DbSet<RegistroBruto> RegistrosBrutos => Set<RegistroBruto>();
    public DbSet<Registro0000>  Registros0000   => Set<Registro0000>();
    public DbSet<Registro0005>  Registros0005   => Set<Registro0005>();
    public DbSet<Registro0100>  Registros0100   => Set<Registro0100>();
    public DbSet<RegistroE100> RegistrosE100 => Set<RegistroE100>();
    public DbSet<RegistroE110> RegistrosE110 => Set<RegistroE110>();
    public DbSet<Registro1010> Registros1010 => Set<Registro1010>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Importacao>(entity =>
        {
            entity.ToTable("Importacoes");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.NomeArquivo).HasMaxLength(255).IsRequired();
            entity.Property(x => x.Status).HasMaxLength(50).IsRequired();
            entity.Property(x => x.VersaoLeiaute).HasMaxLength(10);
            entity.Property(x => x.PeriodoInicial).HasMaxLength(8);
            entity.Property(x => x.PeriodoFinal).HasMaxLength(8);
        });

        modelBuilder.Entity<RegistroBruto>(entity =>
        {
            entity.ToTable("RegistrosBrutos");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.CodigoRegistro).HasMaxLength(10).IsRequired();
            entity.Property(x => x.LinhaOriginal).HasColumnType("longtext").IsRequired();
            entity.Property(x => x.Erro).HasColumnType("longtext");
            entity.HasIndex(x => x.CodigoRegistro);
            entity.HasIndex(x => new { x.ImportacaoId, x.NumeroLinha });
            entity.HasOne(x => x.Importacao)
                .WithMany(x => x.Registros)
                .HasForeignKey(x => x.ImportacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Registro0000>(entity =>
        {
            entity.ToTable("Registros0000");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Reg).HasMaxLength(10).IsRequired();
            entity.Property(x => x.CodVer).HasMaxLength(10);
            entity.Property(x => x.CodFin).HasMaxLength(10);
            entity.Property(x => x.DtIni).HasMaxLength(8);
            entity.Property(x => x.DtFin).HasMaxLength(8);
            entity.Property(x => x.Nome).HasMaxLength(255);
            entity.Property(x => x.Cnpj).HasMaxLength(20);
            entity.Property(x => x.Uf).HasMaxLength(2);
            entity.Property(x => x.Ie).HasMaxLength(30);
            entity.Property(x => x.LinhaOriginal).HasColumnType("longtext").IsRequired();
            entity.HasIndex(x => x.ImportacaoId);
            entity.HasOne(x => x.Importacao)
                .WithMany()
                .HasForeignKey(x => x.ImportacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Registro0005>(entity =>
        {
            entity.ToTable("Registros0005");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Reg).HasMaxLength(10).IsRequired();
            entity.Property(x => x.Fantasia).HasMaxLength(60);
            entity.Property(x => x.Cep).HasMaxLength(8);
            entity.Property(x => x.Logr).HasMaxLength(60);
            entity.Property(x => x.Num).HasMaxLength(10);
            entity.Property(x => x.Compl).HasMaxLength(60);
            entity.Property(x => x.Bairro).HasMaxLength(60);
            entity.Property(x => x.Fone).HasMaxLength(11);
            entity.Property(x => x.Fax).HasMaxLength(11);
            entity.Property(x => x.Email).HasMaxLength(255);
            entity.Property(x => x.LinhaOriginal).HasColumnType("longtext").IsRequired();
            entity.HasIndex(x => x.ImportacaoId);
            entity.HasOne(x => x.Importacao)
                .WithMany()
                .HasForeignKey(x => x.ImportacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Registro0100>(entity =>
        {
            entity.ToTable("Registros0100");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Reg).HasMaxLength(10).IsRequired();
            entity.Property(x => x.Nome).HasMaxLength(100);
            entity.Property(x => x.Cpf).HasMaxLength(14);
            entity.Property(x => x.Crc).HasMaxLength(15);
            entity.Property(x => x.CnpjEsc).HasMaxLength(20);
            entity.Property(x => x.Cep).HasMaxLength(8);
            entity.Property(x => x.Logr).HasMaxLength(60);
            entity.Property(x => x.Num).HasMaxLength(10);
            entity.Property(x => x.Compl).HasMaxLength(60);
            entity.Property(x => x.Bairro).HasMaxLength(60);
            entity.Property(x => x.Fone).HasMaxLength(11);
            entity.Property(x => x.Fax).HasMaxLength(11);
            entity.Property(x => x.Email).HasMaxLength(255);
            entity.Property(x => x.CodMun).HasMaxLength(7);
            entity.Property(x => x.LinhaOriginal).HasColumnType("longtext").IsRequired();
            entity.HasIndex(x => x.ImportacaoId);
            entity.HasOne(x => x.Importacao)
                .WithMany()
                .HasForeignKey(x => x.ImportacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RegistroE100>(entity =>
        {
            entity.ToTable("RegistrosE100");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Reg).HasMaxLength(10).IsRequired();
            entity.Property(x => x.DtIni).HasMaxLength(8);
            entity.Property(x => x.DtFin).HasMaxLength(8);
            entity.Property(x => x.LinhaOriginal).HasColumnType("longtext").IsRequired();
            entity.HasIndex(x => x.ImportacaoId);
            entity.HasOne(x => x.Importacao)
                .WithMany()
                .HasForeignKey(x => x.ImportacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RegistroE110>(entity =>
        {
            entity.ToTable("RegistrosE110");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Reg).HasMaxLength(10).IsRequired();
            entity.Property(x => x.VlTotDebitos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlAjDebitos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlTotAjDebitos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlEstornosCreditos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlTotCreditos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlAjCreditos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlTotAjCreditos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlEstornosDebitos).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlSldCredorAnterior).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlSldApurado).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlTotDed).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlIcmsRecolher).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlSldCredorTransportar).HasColumnType("decimal(18,2)");
            entity.Property(x => x.VlDebEspecial).HasColumnType("decimal(18,2)");
            entity.Property(x => x.LinhaOriginal).HasColumnType("longtext").IsRequired();
            entity.HasIndex(x => x.ImportacaoId);
            entity.HasOne(x => x.Importacao)
                .WithMany()
                .HasForeignKey(x => x.ImportacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Registro1010>(entity =>
        {
            entity.ToTable("Registros1010");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Reg).HasMaxLength(10).IsRequired();
            entity.Property(x => x.IndExp).HasMaxLength(1);
            entity.Property(x => x.IndCcrf).HasMaxLength(1);
            entity.Property(x => x.IndComb).HasMaxLength(1);
            entity.Property(x => x.IndUsina).HasMaxLength(1);
            entity.Property(x => x.IndVa).HasMaxLength(1);
            entity.Property(x => x.IndEe).HasMaxLength(1);
            entity.Property(x => x.IndCart).HasMaxLength(1);
            entity.Property(x => x.IndForm).HasMaxLength(1);
            entity.Property(x => x.IndAer).HasMaxLength(1);
            entity.Property(x => x.IndGiaf1).HasMaxLength(1);
            entity.Property(x => x.IndGiaf3).HasMaxLength(1);
            entity.Property(x => x.IndGiaf4).HasMaxLength(1);
            entity.Property(x => x.IndRestRessarcComplIcms).HasMaxLength(1);
            entity.Property(x => x.LinhaOriginal).HasColumnType("longtext").IsRequired();
            entity.HasIndex(x => x.ImportacaoId);
            entity.HasOne(x => x.Importacao)
                .WithMany()
                .HasForeignKey(x => x.ImportacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

    }
}
