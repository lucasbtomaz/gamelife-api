using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLife.Infrastructure.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TituloNormalizado = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensBiblioteca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plataforma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdicionadoEmUtc = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensBiblioteca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensBiblioteca_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensListaDesejos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plataforma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdicionadoEmUtc = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensListaDesejos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensListaDesejos_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensBiblioteca_JogoId_Plataforma",
                table: "ItensBiblioteca",
                columns: new[] { "JogoId", "Plataforma" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensListaDesejos_JogoId_Plataforma",
                table: "ItensListaDesejos",
                columns: new[] { "JogoId", "Plataforma" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_TituloNormalizado",
                table: "Jogos",
                column: "TituloNormalizado",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensBiblioteca");

            migrationBuilder.DropTable(
                name: "ItensListaDesejos");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
