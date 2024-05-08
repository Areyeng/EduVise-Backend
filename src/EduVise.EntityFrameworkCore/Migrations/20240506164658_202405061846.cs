using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVise.Migrations
{
    /// <inheritdoc />
    public partial class _202405061846 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultyOneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultyTwoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultyThreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SavedResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedResponses_Faculties_FacultyOneId",
                        column: x => x.FacultyOneId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SavedResponses_Faculties_FacultyThreeId",
                        column: x => x.FacultyThreeId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SavedResponses_Faculties_FacultyTwoId",
                        column: x => x.FacultyTwoId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SavedResponses_Learners_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedResponses_FacultyOneId",
                table: "SavedResponses",
                column: "FacultyOneId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedResponses_FacultyThreeId",
                table: "SavedResponses",
                column: "FacultyThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedResponses_FacultyTwoId",
                table: "SavedResponses",
                column: "FacultyTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedResponses_LearnerId",
                table: "SavedResponses",
                column: "LearnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedResponses");
        }
    }
}
