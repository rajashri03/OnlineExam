using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class ques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    userType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Courseid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coursename = table.Column<string>(nullable: true),
                    userid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Courseid);
                    table.ForeignKey(
                        name: "FK_courses_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: true),
                    OptionA = table.Column<string>(nullable: true),
                    OptionB = table.Column<string>(nullable: true),
                    OptionC = table.Column<string>(nullable: true),
                    OptionD = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<string>(nullable: true),
                    userid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subjectid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courseid = table.Column<int>(nullable: false),
                    SubjectName = table.Column<string>(nullable: true),
                    userid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Subjectid);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    userType = table.Column<string>(nullable: true),
                    courseid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.FirstName);
                    table.ForeignKey(
                        name: "FK_StudentInfo_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "Courseid",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    examsetupid = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    examname = table.Column<string>(nullable: true),
                    examdiscription = table.Column<string>(nullable: true),
                    examdate = table.Column<DateTime>(nullable: false),
                    examDuration = table.Column<string>(nullable: true),
                    exampassmarks = table.Column<string>(nullable: true),
                    examtotalmarks = table.Column<string>(nullable: true),
                    examstarttime = table.Column<string>(nullable: true),
                    endTime = table.Column<string>(nullable: true),
                    totalquestion = table.Column<int>(nullable: false),
                    singleQuestionmarks = table.Column<string>(nullable: true),
                    courseid = table.Column<int>(nullable: false),
                    subjectid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.examsetupid);
                    table.ForeignKey(
                        name: "FK_Exams_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "Courseid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Subjects_subjectid",
                        column: x => x.subjectid,
                        principalTable: "Subjects",
                        principalColumn: "Subjectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_userid",
                table: "courses",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_courseid",
                table: "Exams",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_subjectid",
                table: "Exams",
                column: "subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_userid",
                table: "Questions",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_courseid",
                table: "StudentInfo",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_userid",
                table: "Subjects",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
