using Microsoft.EntityFrameworkCore.Migrations;

namespace TestYourStudents.API.Migrations
{
    public partial class configForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_CreatedByUserId1",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_UpdatedByUserId1",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_CreatedByUserId1",
                table: "QuestionResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_UpdatedByUserId1",
                table: "QuestionResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_AspNetUsers_CreatedByUserId1",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_AspNetUsers_UpdatedByUserId1",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizGrade_AspNetUsers_CreatedByUserId1",
                table: "QuizGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizGrade_AspNetUsers_UpdatedByUserId1",
                table: "QuizGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_CreatedByUserId1",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_UpdatedByUserId1",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSession_AspNetUsers_CreatedByUserId1",
                table: "QuizSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSession_AspNetUsers_UpdatedByUserId1",
                table: "QuizSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_CreatedByUserId1",
                table: "QuizSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_UpdatedByUserId1",
                table: "QuizSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEmail_AspNetUsers_CreatedByUserId1",
                table: "StudentEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEmail_AspNetUsers_UpdatedByUserId1",
                table: "StudentEmail");

            migrationBuilder.DropIndex(
                name: "IX_StudentEmail_CreatedByUserId1",
                table: "StudentEmail");

            migrationBuilder.DropIndex(
                name: "IX_StudentEmail_UpdatedByUserId1",
                table: "StudentEmail");

            migrationBuilder.DropIndex(
                name: "IX_QuizSubmission_CreatedByUserId1",
                table: "QuizSubmission");

            migrationBuilder.DropIndex(
                name: "IX_QuizSubmission_UpdatedByUserId1",
                table: "QuizSubmission");

            migrationBuilder.DropIndex(
                name: "IX_QuizSession_CreatedByUserId1",
                table: "QuizSession");

            migrationBuilder.DropIndex(
                name: "IX_QuizSession_UpdatedByUserId1",
                table: "QuizSession");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_CreatedByUserId1",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_UpdatedByUserId1",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizGrade_CreatedByUserId1",
                table: "QuizGrade");

            migrationBuilder.DropIndex(
                name: "IX_QuizGrade_UpdatedByUserId1",
                table: "QuizGrade");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_CreatedByUserId1",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_UpdatedByUserId1",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponse_CreatedByUserId1",
                table: "QuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponse_UpdatedByUserId1",
                table: "QuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_Question_CreatedByUserId1",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_UpdatedByUserId1",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "StudentEmail");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "StudentEmail");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "QuizSubmission");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "QuizSubmission");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "QuizSession");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "QuizSession");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "QuizGrade");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "QuizGrade");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "QuestionResponse");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "QuestionResponse");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId1",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId1",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "StudentEmail",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "StudentEmail",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "QuizSubmission",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "QuizSubmission",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "QuizSession",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "QuizSession",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "QuizQuestion",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "QuizQuestion",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "QuizGrade",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "QuizGrade",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "Quiz",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Quiz",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "QuestionResponse",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "QuestionResponse",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                table: "Question",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Question",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmail_CreatedByUserId",
                table: "StudentEmail",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmail_UpdatedByUserId",
                table: "StudentEmail",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_CreatedByUserId",
                table: "QuizSubmission",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_UpdatedByUserId",
                table: "QuizSubmission",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_CreatedByUserId",
                table: "QuizSession",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_UpdatedByUserId",
                table: "QuizSession",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_CreatedByUserId",
                table: "QuizQuestion",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_UpdatedByUserId",
                table: "QuizQuestion",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizGrade_CreatedByUserId",
                table: "QuizGrade",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizGrade_UpdatedByUserId",
                table: "QuizGrade",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_CreatedByUserId",
                table: "Quiz",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UpdatedByUserId",
                table: "Quiz",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_CreatedByUserId",
                table: "QuestionResponse",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_UpdatedByUserId",
                table: "QuestionResponse",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CreatedByUserId",
                table: "Question",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UpdatedByUserId",
                table: "Question",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_CreatedByUserId",
                table: "Question",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_UpdatedByUserId",
                table: "Question",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_CreatedByUserId",
                table: "QuestionResponse",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_UpdatedByUserId",
                table: "QuestionResponse",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_AspNetUsers_CreatedByUserId",
                table: "Quiz",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_AspNetUsers_UpdatedByUserId",
                table: "Quiz",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizGrade_AspNetUsers_CreatedByUserId",
                table: "QuizGrade",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizGrade_AspNetUsers_UpdatedByUserId",
                table: "QuizGrade",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_CreatedByUserId",
                table: "QuizQuestion",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_UpdatedByUserId",
                table: "QuizQuestion",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSession_AspNetUsers_CreatedByUserId",
                table: "QuizSession",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSession_AspNetUsers_UpdatedByUserId",
                table: "QuizSession",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_CreatedByUserId",
                table: "QuizSubmission",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_UpdatedByUserId",
                table: "QuizSubmission",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEmail_AspNetUsers_CreatedByUserId",
                table: "StudentEmail",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEmail_AspNetUsers_UpdatedByUserId",
                table: "StudentEmail",
                column: "UpdatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_CreatedByUserId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_AspNetUsers_UpdatedByUserId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_CreatedByUserId",
                table: "QuestionResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_UpdatedByUserId",
                table: "QuestionResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_AspNetUsers_CreatedByUserId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_AspNetUsers_UpdatedByUserId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizGrade_AspNetUsers_CreatedByUserId",
                table: "QuizGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizGrade_AspNetUsers_UpdatedByUserId",
                table: "QuizGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_CreatedByUserId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_UpdatedByUserId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSession_AspNetUsers_CreatedByUserId",
                table: "QuizSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSession_AspNetUsers_UpdatedByUserId",
                table: "QuizSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_CreatedByUserId",
                table: "QuizSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_UpdatedByUserId",
                table: "QuizSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEmail_AspNetUsers_CreatedByUserId",
                table: "StudentEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEmail_AspNetUsers_UpdatedByUserId",
                table: "StudentEmail");

            migrationBuilder.DropIndex(
                name: "IX_StudentEmail_CreatedByUserId",
                table: "StudentEmail");

            migrationBuilder.DropIndex(
                name: "IX_StudentEmail_UpdatedByUserId",
                table: "StudentEmail");

            migrationBuilder.DropIndex(
                name: "IX_QuizSubmission_CreatedByUserId",
                table: "QuizSubmission");

            migrationBuilder.DropIndex(
                name: "IX_QuizSubmission_UpdatedByUserId",
                table: "QuizSubmission");

            migrationBuilder.DropIndex(
                name: "IX_QuizSession_CreatedByUserId",
                table: "QuizSession");

            migrationBuilder.DropIndex(
                name: "IX_QuizSession_UpdatedByUserId",
                table: "QuizSession");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_CreatedByUserId",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_UpdatedByUserId",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizGrade_CreatedByUserId",
                table: "QuizGrade");

            migrationBuilder.DropIndex(
                name: "IX_QuizGrade_UpdatedByUserId",
                table: "QuizGrade");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_CreatedByUserId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_UpdatedByUserId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponse_CreatedByUserId",
                table: "QuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponse_UpdatedByUserId",
                table: "QuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_Question_CreatedByUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_UpdatedByUserId",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "StudentEmail",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "StudentEmail",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "StudentEmail",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "StudentEmail",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "QuizSubmission",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "QuizSubmission",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "QuizSubmission",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "QuizSubmission",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "QuizSession",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "QuizSession",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "QuizSession",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "QuizSession",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "QuizQuestion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "QuizQuestion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "QuizQuestion",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "QuizQuestion",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "QuizGrade",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "QuizGrade",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "QuizGrade",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "QuizGrade",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "Quiz",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "Quiz",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "Quiz",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "Quiz",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "QuestionResponse",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "QuestionResponse",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "QuestionResponse",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "QuestionResponse",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedByUserId",
                table: "Question",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "Question",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId1",
                table: "Question",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedByUserId1",
                table: "Question",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmail_CreatedByUserId1",
                table: "StudentEmail",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmail_UpdatedByUserId1",
                table: "StudentEmail",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_CreatedByUserId1",
                table: "QuizSubmission",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmission_UpdatedByUserId1",
                table: "QuizSubmission",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_CreatedByUserId1",
                table: "QuizSession",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_UpdatedByUserId1",
                table: "QuizSession",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_CreatedByUserId1",
                table: "QuizQuestion",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_UpdatedByUserId1",
                table: "QuizQuestion",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizGrade_CreatedByUserId1",
                table: "QuizGrade",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizGrade_UpdatedByUserId1",
                table: "QuizGrade",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_CreatedByUserId1",
                table: "Quiz",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UpdatedByUserId1",
                table: "Quiz",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_CreatedByUserId1",
                table: "QuestionResponse",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_UpdatedByUserId1",
                table: "QuestionResponse",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CreatedByUserId1",
                table: "Question",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UpdatedByUserId1",
                table: "Question",
                column: "UpdatedByUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_CreatedByUserId1",
                table: "Question",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AspNetUsers_UpdatedByUserId1",
                table: "Question",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_CreatedByUserId1",
                table: "QuestionResponse",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponse_AspNetUsers_UpdatedByUserId1",
                table: "QuestionResponse",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_AspNetUsers_CreatedByUserId1",
                table: "Quiz",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_AspNetUsers_UpdatedByUserId1",
                table: "Quiz",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizGrade_AspNetUsers_CreatedByUserId1",
                table: "QuizGrade",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizGrade_AspNetUsers_UpdatedByUserId1",
                table: "QuizGrade",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_CreatedByUserId1",
                table: "QuizQuestion",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_AspNetUsers_UpdatedByUserId1",
                table: "QuizQuestion",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSession_AspNetUsers_CreatedByUserId1",
                table: "QuizSession",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSession_AspNetUsers_UpdatedByUserId1",
                table: "QuizSession",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_CreatedByUserId1",
                table: "QuizSubmission",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizSubmission_AspNetUsers_UpdatedByUserId1",
                table: "QuizSubmission",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEmail_AspNetUsers_CreatedByUserId1",
                table: "StudentEmail",
                column: "CreatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEmail_AspNetUsers_UpdatedByUserId1",
                table: "StudentEmail",
                column: "UpdatedByUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
