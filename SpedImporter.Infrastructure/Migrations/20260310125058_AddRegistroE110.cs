using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpedImporter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRegistroE110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrosE110",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImportacaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroLinha = table.Column<int>(type: "int", nullable: false),
                    Reg = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VlTotDebitos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlAjDebitos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlTotAjDebitos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlEstornosCreditos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlTotCreditos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlAjCreditos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlTotAjCreditos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlEstornosDebitos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlSldCredorAnterior = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlSldApurado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlTotDed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlIcmsRecolher = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlSldCredorTransportar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlDebEspecial = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LinhaOriginal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosE110", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosE110_Importacoes_ImportacaoId",
                        column: x => x.ImportacaoId,
                        principalTable: "Importacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosE110_ImportacaoId",
                table: "RegistrosE110",
                column: "ImportacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosE110");
        }
    }
}
