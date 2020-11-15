using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class responses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    JobPositionId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ApplicationDeadline = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.JobPositionId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PersonType = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    LinkCV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(nullable: false),
                    Quest = table.Column<string>(nullable: true),
                    QuestionType = table.Column<int>(nullable: false),
                    Option1 = table.Column<string>(nullable: true),
                    Option2 = table.Column<string>(nullable: true),
                    Option3 = table.Column<string>(nullable: true),
                    Option4 = table.Column<string>(nullable: true),
                    Option5 = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<int>(nullable: false),
                    Cancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HoursLimitTime = table.Column<int>(nullable: false),
                    MinutesLimitTime = table.Column<int>(nullable: false),
                    MaximumScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(nullable: false),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FeedbackType = table.Column<int>(nullable: false),
                    FeedbackText = table.Column<string>(nullable: true),
                    JobPositionId = table.Column<Guid>(nullable: false),
                    ApplicantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Persons_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPositions",
                        principalColumn: "JobPositionId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Interviews",
                columns: table => new
                {
                    InterviewId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    DurationMinutes = table.Column<int>(nullable: false),
                    DurationHours = table.Column<int>(nullable: false),
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
                name: "QuestionResponses",
                columns: table => new
                {
                    QuestionResponseId = table.Column<Guid>(nullable: false),
                    TestId = table.Column<Guid>(nullable: false),
                    InterviewId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    CheckAnswer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponses", x => x.QuestionResponseId);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "InterviewId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponses_Tests_TestId",
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
                    InterviewId = table.Column<Guid>(nullable: false),
                    UserScore = table.Column<double>(nullable: false)
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
                name: "IX_Applications_ApplicantId",
                table: "Applications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobPositionId",
                table: "Applications",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ApplicationId",
                table: "Interviews",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_PersonId",
                table: "Interviews",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_InterviewId",
                table: "QuestionResponses",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_QuestionId",
                table: "QuestionResponses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_TestId",
                table: "QuestionResponses",
                column: "TestId");

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
                name: "QuestionResponses");

            migrationBuilder.DropTable(
                name: "TestsToInterviews");

            migrationBuilder.DropTable(
                name: "TestsToQuestions");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "JobPositions");
        }
    }
}
