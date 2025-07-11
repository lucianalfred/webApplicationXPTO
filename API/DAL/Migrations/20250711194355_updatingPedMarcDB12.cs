using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatingPedMarcDB12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "PedidosDeMarcacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "PedidosDeMarcacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDeMarcacao_AspNetUsers_IdUsuario",
                table: "PedidosDeMarcacao",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
