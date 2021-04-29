using Microsoft.EntityFrameworkCore.Migrations;

namespace TestYourStudents.API.Migrations
{
    public partial class studentForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "QuizSubmission",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "QuizSession",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorId",
                table: "Course",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_StudentId",
                table: "QuizSubmission",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_StudentId",
                table: "QuizSession",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ProfessorId",
                table: "Course",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_ProfessorId",
                table: "Course",
                column: "ProfessorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSession_AspNetUsers_StudentId",
                table: "QuizSession",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_StudentId",
                table: "QuizSubmission",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_ProfessorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSession_AspNetUsers_StudentId",
                table: "QuizSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_StudentId",
                table: "QuizSubmission");

            migrationBuilder.DropIndex(
                name: "IX_QuizSubmission_StudentId",
                table: "QuizSubmission");

            migrationBuilder.DropIndex(
                name: "IX_QuizSession_StudentId",
                table: "QuizSession");

            migrationBuilder.DropIndex(
                name: "IX_Course_ProfessorId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "QuizSubmission");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "QuizSession");

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorId",
                table: "Course",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
