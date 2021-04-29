using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestYourStudents.API.Migrations
{
    public partial class course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "StudentEmail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Quiz",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: false),
                    UpdatedByUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_AspNetUsers_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmail_CourseId",
                table: "StudentEmail",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_CourseId",
                table: "Quiz",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CourseId",
                table: "Question",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CreatedByUserId",
                table: "Course",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_UpdatedByUserId",
                table: "Course",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Course_CourseId",
                table: "Quiz",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEmail_Course_CourseId",
                table: "StudentEmail",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Course_CourseId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Course_CourseId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEmail_Course_CourseId",
                table: "StudentEmail");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_StudentEmail_CourseId",
                table: "StudentEmail");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_CourseId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Question_CourseId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentEmail");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Question");
        }
    }
}
