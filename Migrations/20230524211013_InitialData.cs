using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("8628d41c-2029-4a05-aa85-d462c032e85e"), null, "Actividades personales", 20 },
                    { new Guid("fab3c6b5-7b27-47be-a3c9-c997f2b7067b"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreatedAt", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("5470a6ed-e36b-4f30-b0d9-58d4c9933758"), new Guid("8628d41c-2029-4a05-aa85-d462c032e85e"), new DateTime(2023, 5, 24, 16, 10, 13, 440, DateTimeKind.Local).AddTicks(7010), "Arregalr la oficina por completo y ordenar el closet", 0, "Arreglar la oficina" },
                    { new Guid("862589ec-ee6b-4be7-8412-c9727cd53bed"), new Guid("fab3c6b5-7b27-47be-a3c9-c997f2b7067b"), new DateTime(2023, 5, 24, 16, 10, 13, 440, DateTimeKind.Local).AddTicks(6970), "Terminar la prueba de una api en .Net Framework Core", 2, "Terminar la prueba" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("5470a6ed-e36b-4f30-b0d9-58d4c9933758"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("862589ec-ee6b-4be7-8412-c9727cd53bed"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("8628d41c-2029-4a05-aa85-d462c032e85e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("fab3c6b5-7b27-47be-a3c9-c997f2b7067b"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
