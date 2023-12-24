using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentGradeReport.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingCorseCodeAsIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_CourseId",
                table: "Grades");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("11dbdcfa-8cd9-4c99-8a5d-89d551a0d07e"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f48ba04f-2fe7-4ca8-857e-f88fdd27bae8"));

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Grades");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Grades",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Courses_CourseCode",
                table: "Courses",
                column: "CourseCode");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Email", "Name", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("81a91acb-68ff-49d4-b5ca-63552b7e0bc5"), "Addis Ababa", new DateTime(2023, 12, 24, 19, 57, 44, 753, DateTimeKind.Local).AddTicks(416), "Admin", "rehana@gmail.com", "Rihana Seid", "098327487238", null, null },
                    { new Guid("8d8fd6aa-169b-46d3-a5f5-ea0a4944c423"), "Addis Ababa", new DateTime(2023, 12, 24, 19, 57, 44, 753, DateTimeKind.Local).AddTicks(434), "Admin", "habibaseid@gmail.com", "Habiba Seid", "09832748723", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseCode",
                table: "Grades",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCode",
                table: "Courses",
                column: "CourseCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_CourseCode",
                table: "Grades",
                column: "CourseCode",
                principalTable: "Courses",
                principalColumn: "CourseCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_CourseCode",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_CourseCode",
                table: "Grades");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Courses_CourseCode",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseCode",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("81a91acb-68ff-49d4-b5ca-63552b7e0bc5"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8d8fd6aa-169b-46d3-a5f5-ea0a4944c423"));

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Grades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "Email", "Name", "PhoneNumber", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("11dbdcfa-8cd9-4c99-8a5d-89d551a0d07e"), "Addis Ababa", new DateTime(2023, 12, 24, 17, 34, 59, 949, DateTimeKind.Local).AddTicks(1752), "Admin", "habibaseid@gmail.com", "Habiba Seid", "09832748723", null, null },
                    { new Guid("f48ba04f-2fe7-4ca8-857e-f88fdd27bae8"), "Addis Ababa", new DateTime(2023, 12, 24, 17, 34, 59, 949, DateTimeKind.Local).AddTicks(1746), "Admin", "rehana@gmail.com", "Rihana Seid", "098327487238", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
