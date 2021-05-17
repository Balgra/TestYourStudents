using Microsoft.EntityFrameworkCore.Migrations;

namespace TestYourStudents.API.Migrations
{
    public partial class SubmissionForeignKeyToQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "QuizSubmission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_QuizId",
                table: "QuizSubmission",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_Quiz_QuizId",
                table: "QuizSubmission",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_Quiz_QuizId",
                table: "QuizSubmission");

            migrationBuilder.DropIndex(
                name: "IX_QuizSubmission_QuizId",
                table: "QuizSubmission");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "QuizSubmission");
        }
    }
}
