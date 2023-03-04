using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class Mudandotipodedelecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_IdGerente",
                table: "Cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_IdGerente",
                table: "Cinemas",
                column: "IdGerente",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_IdGerente",
                table: "Cinemas");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_IdGerente",
                table: "Cinemas",
                column: "IdGerente",
                principalTable: "Gerentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
