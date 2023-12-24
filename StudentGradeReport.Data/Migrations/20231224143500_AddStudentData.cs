using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentGradeReport.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Email", "Name", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11dbdcfa-8cd9-4c99-8a5d-89d551a0d07e"), "Addis Ababa", new DateTime(2023, 12, 24, 17, 34, 59, 949, DateTimeKind.Local).AddTicks(1752), "Admin", "habibaseid@gmail.com", "Habiba Seid", "09832748723", null, null },
                    { new Guid("f48ba04f-2fe7-4ca8-857e-f88fdd27bae8"), "Addis Ababa", new DateTime(2023, 12, 24, 17, 34, 59, 949, DateTimeKind.Local).AddTicks(1746), "Admin", "rehana@gmail.com", "Rihana Seid", "098327487238", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11dbdcfa-8cd9-4c99-8a5d-89d551a0d07e"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f48ba04f-2fe7-4ca8-857e-f88fdd27bae8"));
        }
    }
}
