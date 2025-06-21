using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminstractivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminstractivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlDaFotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoDoUtilizador = table.Column<bool>(type: "bit", nullable: false),
                    TipoUtilizador = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtentesRegistado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtentesRegistado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtentesRegistado_Utilizadores_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidosDeMarcacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoDoPedidoDeMarcacao = table.Column<int>(type: "int", nullable: false),
                    DataDeCriacaoDoPedidoMarcacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntervaloDeDatasDoPedidoDeMarcacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminstractivoId = table.Column<int>(type: "int", nullable: true),
                    DataDeAgendamentoDoPedidoDeMarcacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtenteRegistadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDeMarcacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosDeMarcacao_Adminstractivos_AdminstractivoId",
                        column: x => x.AdminstractivoId,
                        principalTable: "Adminstractivos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PedidosDeMarcacao_UtentesRegistado_UtenteRegistadoId",
                        column: x => x.UtenteRegistadoId,
                        principalTable: "UtentesRegistado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActosClinico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeActoClinico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubSistemaDeSaude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfissionalId = table.Column<int>(type: "int", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PedidoDeMarcacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActosClinico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActosClinico_PedidosDeMarcacao_PedidoDeMarcacaoId",
                        column: x => x.PedidoDeMarcacaoId,
                        principalTable: "PedidosDeMarcacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActosClinico_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActosClinico_PedidoDeMarcacaoId",
                table: "ActosClinico",
                column: "PedidoDeMarcacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ActosClinico_ProfissionalId",
                table: "ActosClinico",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeMarcacao_AdminstractivoId",
                table: "PedidosDeMarcacao",
                column: "AdminstractivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeMarcacao_UtenteRegistadoId",
                table: "PedidosDeMarcacao",
                column: "UtenteRegistadoId");

            migrationBuilder.CreateIndex(
                name: "IX_UtentesRegistado_IdUsuario",
                table: "UtentesRegistado",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActosClinico");

            migrationBuilder.DropTable(
                name: "PedidosDeMarcacao");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Adminstractivos");

            migrationBuilder.DropTable(
                name: "UtentesRegistado");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
