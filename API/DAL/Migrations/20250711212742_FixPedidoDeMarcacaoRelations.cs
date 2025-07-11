using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixPedidoDeMarcacaoRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_UtentesRegistados_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_UtentesRegistados_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario",
                principalTable: "UtentesRegistados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
