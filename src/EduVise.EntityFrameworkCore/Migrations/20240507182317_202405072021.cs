using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVise.Migrations
{
    /// <inheritdoc />
    public partial class _202405072021 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LearnerId",
                table: "Responses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_LearnerId",
                table: "Responses",
                column: "LearnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Learners_LearnerId",
                table: "Responses",
                column: "LearnerId",
                principalTable: "Learners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Learners_LearnerId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_LearnerId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "LearnerId",
                table: "Responses");
        }
    }
}
