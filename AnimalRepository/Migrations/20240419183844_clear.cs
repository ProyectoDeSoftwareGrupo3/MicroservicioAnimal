using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalRepository.Migrations
{
    /// <inheritdoc />
    public partial class clear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalRaza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalRaza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalRaza_AnimalTipo_TipoId",
                        column: x => x.TipoId,
                        principalTable: "AnimalTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalRaza_TipoId",
                table: "AnimalRaza",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalRaza");

            migrationBuilder.DropTable(
                name: "AnimalTipo");
        }
    }
}
