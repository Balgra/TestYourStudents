using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestYourStudents.API.Migrations
{
    public partial class InitialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    NumberOfMinutes = table.Column<uint>(nullable: false),
                    VisibleForStudents = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quiz_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizSubmission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizSubmission_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizSubmission_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentEmail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEmail_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEmail_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true),
                    QuestionName = table.Column<string>(nullable: true),
                    QuizId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizSession",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizSession_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizSession_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizSession_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizGrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true),
                    Grade = table.Column<float>(nullable: false),
                    QuizSubmissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizGrade_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizGrade_QuizSubmission_QuizSubmissionId",
                        column: x => x.QuizSubmissionId,
                        principalTable: "QuizSubmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizGrade_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    Feedback = table.Column<string>(nullable: true),
                    QuizSubmissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_QuizSubmission_QuizSubmissionId",
                        column: x => x.QuizSubmissionId,
                        principalTable: "QuizSubmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    UpdatedByUserId1 = table.Column<string>(nullable: true),
                    QuizId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_AspNetUsers_UpdatedByUserId1",
                        column: x => x.UpdatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_CreatedByUserId1",
                table: "Question",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UpdatedByUserId1",
                table: "Question",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_CreatedByUserId1",
                table: "QuestionResponse",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_QuestionId",
                table: "QuestionResponse",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_QuizSubmissionId",
                table: "QuestionResponse",
                column: "QuizSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_UpdatedByUserId1",
                table: "QuestionResponse",
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
                name: "IX_QuizGrade_CreatedByUserId1",
                table: "QuizGrade",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizGrade_QuizSubmissionId",
                table: "QuizGrade",
                column: "QuizSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizGrade_UpdatedByUserId1",
                table: "QuizGrade",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_CreatedByUserId1",
                table: "QuizQuestion",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuizId",
                table: "QuizQuestion",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_UpdatedByUserId1",
                table: "QuizQuestion",
                column: "UpdatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_CreatedByUserId1",
                table: "QuizSession",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_QuizId",
                table: "QuizSession",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSession_UpdatedByUserId1",
                table: "QuizSession",
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
                name: "IX_StudentEmail_CreatedByUserId1",
                table: "StudentEmail",
                column: "CreatedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmail_UpdatedByUserId1",
                table: "StudentEmail",
                column: "UpdatedByUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionResponse");

            migrationBuilder.DropTable(
                name: "QuizGrade");

            migrationBuilder.DropTable(
                name: "QuizQuestion");

            migrationBuilder.DropTable(
                name: "QuizSession");

            migrationBuilder.DropTable(
                name: "StudentEmail");

            migrationBuilder.DropTable(
                name: "QuizSubmission");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
