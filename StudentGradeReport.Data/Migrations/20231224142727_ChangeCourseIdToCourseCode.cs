using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradeReport.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCourseIdToCourseCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Grades");
        }
    }
}
