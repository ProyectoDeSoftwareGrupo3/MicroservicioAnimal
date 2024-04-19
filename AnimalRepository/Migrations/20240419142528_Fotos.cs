using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalRepository.Migrations
{
    /// <inheritdoc />
    public partial class Fotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Animal_GaleriaId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AnimalGaleria");

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GaleriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foto_AnimalGaleria_GaleriaId",
                        column: x => x.GaleriaId,
                        principalTable: "AnimalGaleria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_GaleriaId",
                table: "Animal",
                column: "GaleriaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foto_GaleriaId",
                table: "Foto",
                column: "GaleriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Animal_GaleriaId",
                table: "Animal");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "AnimalGaleria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_GaleriaId",
                table: "Animal",
                column: "GaleriaId");
        }
    }
}
