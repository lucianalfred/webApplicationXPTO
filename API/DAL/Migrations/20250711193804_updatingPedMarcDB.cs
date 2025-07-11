using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatingPedMarcDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_UtentesRegistados_UtenteId",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDeMarcacao_UtenteId",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "PedidosDeMarcacao");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "PedidosDeMarcacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDeMarcacao_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_UtentesRegistados_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario",
                principalTable: "UtentesRegistados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_UtentesRegistados_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDeMarcacao_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "PedidosDeMarcacao");

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
                name: "FK_PedidosDeMarcacao_UtentesRegistados_UtenteId",
                table: "PedidosDeMarcacao",
                column: "UtenteId",
                principalTable: "UtentesRegistados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
