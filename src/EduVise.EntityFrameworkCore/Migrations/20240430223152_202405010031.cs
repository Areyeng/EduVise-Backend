using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVise.Migrations
{
    /// <inheritdoc />
    public partial class _202405010031 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CriticalThinking",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EffectiveCommunication",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnvironmentalSustainability",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HealthcareProficiency",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructionalDesign",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Leadership",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LegalReasoning",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProblemSolving",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriticalThinking",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "EffectiveCommunication",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "EnvironmentalSustainability",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "HealthcareProficiency",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "InstructionalDesign",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Leadership",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "LegalReasoning",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "ProblemSolving",
                table: "Faculties");
        }
    }
}
