using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class IdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exams",
                newName: "ExamId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Answers",
                newName: "AnswerId");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "Exams",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "Answers",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
