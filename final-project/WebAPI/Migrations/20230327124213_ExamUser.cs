using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ExamUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamUser");

            migrationBuilder.CreateTable(
                name: "ExamUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamUsers_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamUsers_Users_userName",
                        column: x => x.userName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamUsers_ExamId",
                table: "ExamUsers",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamUsers_userName",
                table: "ExamUsers",
                column: "userName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamUsers");

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
    }
}
