using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class interview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestToQuestions");

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    InterviewId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.InterviewId);
                    table.ForeignKey(
                        name: "FK_Interviews_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TestsToQuestions",
                columns: table => new
                {
                    TestsToQuestionsId = table.Column<Guid>(nullable: false),
                    TestId = table.Column<Guid>(nullable: false),
                    QuestionID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsToQuestions", x => x.TestsToQuestionsId);
                    table.ForeignKey(
                        name: "FK_TestsToQuestions_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestsToQuestions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestsToInterviews",
                columns: table => new
                {
                    TestsToInterviewsId = table.Column<Guid>(nullable: false),
                    TestId = table.Column<Guid>(nullable: false),
                    InterviewId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsToInterviews", x => x.TestsToInterviewsId);
                    table.ForeignKey(
                        name: "FK_TestsToInterviews_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "InterviewId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestsToInterviews_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ApplicationId",
                table: "Interviews",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_PersonId",
                table: "Interviews",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TestsToInterviews_InterviewId",
                table: "TestsToInterviews",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_TestsToInterviews_TestId",
                table: "TestsToInterviews",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestsToQuestions_QuestionID",
                table: "TestsToQuestions",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestsToQuestions_TestId",
                table: "TestsToQuestions",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestsToInterviews");

            migrationBuilder.DropTable(
                name: "TestsToQuestions");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.CreateTable(
                name: "TestToQuestions",
                columns: table => new
                {
                    TestToQuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestToQuestions", x => x.TestToQuestionsId);
                    table.ForeignKey(
                        name: "FK_TestToQuestions_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestToQuestions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestToQuestions_QuestionID",
                table: "TestToQuestions",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestToQuestions_TestId",
                table: "TestToQuestions",
                column: "TestId");
        }
    }
}
