using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "Questions",
                newName: "ExamID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                newName: "IX_Questions_ExamID");

            migrationBuilder.AlterColumn<int>(
                name: "ExamID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamID",
                table: "Questions",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "ExamID",
                table: "Questions",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExamID",
                table: "Questions",
                newName: "IX_Questions_ExamId");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }
    }
}
