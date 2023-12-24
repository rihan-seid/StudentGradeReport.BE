using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentGradeReport.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("81a91acb-68ff-49d4-b5ca-63552b7e0bc5"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8d8fd6aa-169b-46d3-a5f5-ea0a4944c423"));

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Email", "Name", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("893fef91-5966-4e24-88d4-9527d52c82f6"), "Addis Ababa", new DateTime(2023, 12, 24, 20, 20, 1, 699, DateTimeKind.Local).AddTicks(4480), "Admin", "habibaseid@gmail.com", "Habiba Seid", "09832748723", null, null },
                    { new Guid("e88af3d4-9723-4566-85fa-7f58f0e916a4"), "Addis Ababa", new DateTime(2023, 12, 24, 20, 20, 1, 699, DateTimeKind.Local).AddTicks(4475), "Admin", "rehana@gmail.com", "Rihana Seid", "098327487238", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("893fef91-5966-4e24-88d4-9527d52c82f6"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e88af3d4-9723-4566-85fa-7f58f0e916a4"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Email", "Name", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("81a91acb-68ff-49d4-b5ca-63552b7e0bc5"), "Addis Ababa", new DateTime(2023, 12, 24, 19, 57, 44, 753, DateTimeKind.Local).AddTicks(416), "Admin", "rehana@gmail.com", "Rihana Seid", "098327487238", null, null },
                    { new Guid("8d8fd6aa-169b-46d3-a5f5-ea0a4944c423"), "Addis Ababa", new DateTime(2023, 12, 24, 19, 57, 44, 753, DateTimeKind.Local).AddTicks(434), "Admin", "habibaseid@gmail.com", "Habiba Seid", "09832748723", null, null }
                });
        }
    }
}
