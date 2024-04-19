using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalRepository.Migrations
{
    /// <inheritdoc />
    public partial class CambiodeIdS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalTipo_AnimalRaza_AnimalRazaId",
                table: "AnimalTipo");

            migrationBuilder.DropIndex(
                name: "IX_AnimalTipo_AnimalRazaId",
                table: "AnimalTipo");

            migrationBuilder.DropColumn(
                name: "AnimalRazaId",
                table: "AnimalTipo");

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "AnimalRaza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalRaza_TipoId",
                table: "AnimalRaza",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalRaza_AnimalTipo_TipoId",
                table: "AnimalRaza",
                column: "TipoId",
                principalTable: "AnimalTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalRaza_AnimalTipo_TipoId",
                table: "AnimalRaza");

            migrationBuilder.DropIndex(
                name: "IX_AnimalRaza_TipoId",
                table: "AnimalRaza");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "AnimalRaza");

            migrationBuilder.AddColumn<int>(
                name: "AnimalRazaId",
                table: "AnimalTipo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTipo_AnimalRazaId",
                table: "AnimalTipo",
                column: "AnimalRazaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalTipo_AnimalRaza_AnimalRazaId",
                table: "AnimalTipo",
                column: "AnimalRazaId",
                principalTable: "AnimalRaza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
