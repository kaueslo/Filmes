using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandorelacaoentregerenteecinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGerente",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_IdGerente",
                table: "Cinemas",
                column: "IdGerente");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_IdGerente",
                table: "Cinemas",
                column: "IdGerente",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_IdGerente",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_IdGerente",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "IdGerente",
                table: "Cinemas");
        }
    }
}
