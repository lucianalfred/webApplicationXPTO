using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "PedidosDeMarcacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeMarcacao_UtenteId",
                table: "PedidosDeMarcacao",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_UtentesRegistado_UtenteId",
                table: "PedidosDeMarcacao",
                column: "UtenteId",
                principalTable: "UtentesRegistado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_UtentesRegistado_UtenteId",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDeMarcacao_UtenteId",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "PedidosDeMarcacao");
        }
    }
}
