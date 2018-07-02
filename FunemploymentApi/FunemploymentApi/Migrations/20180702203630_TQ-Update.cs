using Microsoft.EntityFrameworkCore.Migrations;

namespace FunemploymentApi.Migrations
{
    public partial class TQUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "TechnicalQuestions",
                newName: "ProblemDomain");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "TechnicalQuestions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "TechnicalQuestions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Output",
                table: "TechnicalQuestions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "TechnicalQuestions");

            migrationBuilder.DropColumn(
                name: "Input",
                table: "TechnicalQuestions");

            migrationBuilder.DropColumn(
                name: "Output",
                table: "TechnicalQuestions");

            migrationBuilder.RenameColumn(
                name: "ProblemDomain",
                table: "TechnicalQuestions",
                newName: "Content");
        }
    }
}
