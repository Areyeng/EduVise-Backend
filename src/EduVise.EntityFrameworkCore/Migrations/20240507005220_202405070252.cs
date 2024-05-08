using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVise.Migrations
{
    /// <inheritdoc />
    public partial class _202405070252 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearnerSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredSubjects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriticalThinking = table.Column<int>(type: "int", nullable: false),
                    ProblemSolving = table.Column<int>(type: "int", nullable: false),
                    EffectiveCommunication = table.Column<int>(type: "int", nullable: false),
                    HealthcareProficiency = table.Column<int>(type: "int", nullable: false),
                    InstructionalDesign = table.Column<int>(type: "int", nullable: false),
                    LegalReasoning = table.Column<int>(type: "int", nullable: false),
                    Leadership = table.Column<int>(type: "int", nullable: false),
                    EnvironmentalSustainability = table.Column<int>(type: "int", nullable: false),
                    LearnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearnerSkills_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearnerSkills_LearnerId",
                table: "LearnerSkills",
                column: "LearnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearnerSkills");
        }
    }
}
