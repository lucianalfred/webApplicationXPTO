using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActosClinico_Profissionais_ProfissionalId",
                table: "ActosClinico");

            migrationBuilder.DropIndex(
                name: "IX_ActosClinico_ProfissionalId",
                table: "ActosClinico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActosClinico_ProfissionalId",
                table: "ActosClinico",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActosClinico_Profissionais_ProfissionalId",
                table: "ActosClinico",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }
    }
}
