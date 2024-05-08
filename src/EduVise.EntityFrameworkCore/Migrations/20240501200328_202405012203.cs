using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVise.Migrations
{
    /// <inheritdoc />
    public partial class _202405012203 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Skill",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skill",
                table: "Questions");
        }
    }
}
