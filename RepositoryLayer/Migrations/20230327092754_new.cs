using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "StudentInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "studentid",
                table: "StudentInfo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo",
                column: "studentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo");

            migrationBuilder.DropColumn(
                name: "studentid",
                table: "StudentInfo");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "StudentInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo",
                column: "FirstName");
        }
    }
}
