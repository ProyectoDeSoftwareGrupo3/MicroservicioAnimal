using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalGaleria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalGaleria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalRaza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalRaza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalRazaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalTipo_AnimalRaza_AnimalRazaId",
                        column: x => x.AnimalRazaId,
                        principalTable: "AnimalRaza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalTipoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GaleriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adoptado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalGaleria_GaleriaId",
                        column: x => x.GaleriaId,
                        principalTable: "AnimalGaleria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_AnimalTipo_AnimalTipoId",
                        column: x => x.AnimalTipoId,
                        principalTable: "AnimalTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AnimalTipoId",
                table: "Animal",
                column: "AnimalTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_GaleriaId",
                table: "Animal",
                column: "GaleriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTipo_AnimalRazaId",
                table: "AnimalTipo",
                column: "AnimalRazaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "AnimalGaleria");

            migrationBuilder.DropTable(
                name: "AnimalTipo");

            migrationBuilder.DropTable(
                name: "AnimalRaza");
        }
    }
}
