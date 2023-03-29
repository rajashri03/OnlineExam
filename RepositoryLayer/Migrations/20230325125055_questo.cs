using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class questo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "courseid",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_courseid",
                table: "Questions",
                column: "courseid");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_courses_courseid",
                table: "Questions",
                column: "courseid",
                principalTable: "courses",
                principalColumn: "Courseid",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_courses_courseid",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_courseid",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "courseid",
                table: "Questions");
        }
    }
}
