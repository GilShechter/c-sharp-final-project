using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class mtonusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_TeacherName",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Exams_ExamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ExamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Exams_TeacherName",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExamUser",
                columns: table => new
                {
                    ExamsExamId = table.Column<int>(type: "int", nullable: false),
                    StudentsName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamUser", x => new { x.ExamsExamId, x.StudentsName });
                    table.ForeignKey(
                        name: "FK_ExamUser_Exams_ExamsExamId",
                        column: x => x.ExamsExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamUser_Users_StudentsName",
                        column: x => x.StudentsName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamUser_StudentsName",
                table: "ExamUser",
                column: "StudentsName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamUser");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ExamId",
                table: "Users",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_TeacherName",
                table: "Exams",
                column: "TeacherName");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_TeacherName",
                table: "Exams",
                column: "TeacherName",
                principalTable: "Users",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Exams_ExamId",
                table: "Users",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId");
        }
    }
}
