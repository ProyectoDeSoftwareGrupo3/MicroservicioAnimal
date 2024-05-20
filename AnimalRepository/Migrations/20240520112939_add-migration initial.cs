using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalRepository.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnimalRaza",
                columns: new[] { "Id", "Descripcion", "TipoId" },
                values: new object[,]
                {
                    { 1, "Mestizo", 1 },
                    { 2, "Otro", 1 },
                    { 3, "Labrador Retriever", 1 },
                    { 4, "Bulldog", 1 },
                    { 5, "Beagle", 1 },
                    { 6, "Poodle", 1 },
                    { 7, "German Shepherd", 1 },
                    { 8, "Golden Retriever", 1 },
                    { 9, "Chihuahua", 1 },
                    { 10, "Boxer", 1 },
                    { 11, "Mestizo", 2 },
                    { 12, "Otro", 2 },
                    { 13, "Siamese", 2 },
                    { 14, "Persian", 2 },
                    { 15, "Maine Coon", 2 },
                    { 16, "Ragdoll", 2 },
                    { 17, "Bengal", 2 },
                    { 18, "Sphynx", 2 },
                    { 19, "Russian Blue", 2 },
                    { 20, "Scottish Fold", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AnimalRaza",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
