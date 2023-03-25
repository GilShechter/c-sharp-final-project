using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class teacherid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Exams");

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
