using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVise.Migrations
{
    /// <inheritdoc />
    public partial class _202404251432 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courses",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Institutions",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Institution",
                table: "Events");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerInstitutions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstitutionId",
                table: "LearnerInstitutions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerFundings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FundingId",
                table: "LearnerFundings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerEvents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "LearnerEvents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerCourses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "LearnerCourses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId",
                table: "Faculties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FacultyId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LearnerInstitutions_InstitutionId",
                table: "LearnerInstitutions",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerInstitutions_LearnerId",
                table: "LearnerInstitutions",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerFundings_FundingId",
                table: "LearnerFundings",
                column: "FundingId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerFundings_LearnerId",
                table: "LearnerFundings",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerEvents_EventId",
                table: "LearnerEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerEvents_LearnerId",
                table: "LearnerEvents",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerCourses_CourseId",
                table: "LearnerCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerCourses_LearnerId",
                table: "LearnerCourses",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_InstitutionId",
                table: "Faculties",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_InstitutionId",
                table: "Events",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Faculties_FacultyId",
                table: "Courses",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Institutions_InstitutionId",
                table: "Events",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Institutions_InstitutionId",
                table: "Faculties",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerCourses_Courses_CourseId",
                table: "LearnerCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerCourses_Learners_LearnerId",
                table: "LearnerCourses",
                column: "LearnerId",
                principalTable: "Learners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerEvents_Events_EventId",
                table: "LearnerEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerEvents_Learners_LearnerId",
                table: "LearnerEvents",
                column: "LearnerId",
                principalTable: "Learners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerFundings_Fundings_FundingId",
                table: "LearnerFundings",
                column: "FundingId",
                principalTable: "Fundings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerFundings_Learners_LearnerId",
                table: "LearnerFundings",
                column: "LearnerId",
                principalTable: "Learners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerInstitutions_Institutions_InstitutionId",
                table: "LearnerInstitutions",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearnerInstitutions_Learners_LearnerId",
                table: "LearnerInstitutions",
                column: "LearnerId",
                principalTable: "Learners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Faculties_FacultyId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Institutions_InstitutionId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Institutions_InstitutionId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerCourses_Courses_CourseId",
                table: "LearnerCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerCourses_Learners_LearnerId",
                table: "LearnerCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerEvents_Events_EventId",
                table: "LearnerEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerEvents_Learners_LearnerId",
                table: "LearnerEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerFundings_Fundings_FundingId",
                table: "LearnerFundings");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerFundings_Learners_LearnerId",
                table: "LearnerFundings");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerInstitutions_Institutions_InstitutionId",
                table: "LearnerInstitutions");

            migrationBuilder.DropForeignKey(
                name: "FK_LearnerInstitutions_Learners_LearnerId",
                table: "LearnerInstitutions");

            migrationBuilder.DropIndex(
                name: "IX_LearnerInstitutions_InstitutionId",
                table: "LearnerInstitutions");

            migrationBuilder.DropIndex(
                name: "IX_LearnerInstitutions_LearnerId",
                table: "LearnerInstitutions");

            migrationBuilder.DropIndex(
                name: "IX_LearnerFundings_FundingId",
                table: "LearnerFundings");

            migrationBuilder.DropIndex(
                name: "IX_LearnerFundings_LearnerId",
                table: "LearnerFundings");

            migrationBuilder.DropIndex(
                name: "IX_LearnerEvents_EventId",
                table: "LearnerEvents");

            migrationBuilder.DropIndex(
                name: "IX_LearnerEvents_LearnerId",
                table: "LearnerEvents");

            migrationBuilder.DropIndex(
                name: "IX_LearnerCourses_CourseId",
                table: "LearnerCourses");

            migrationBuilder.DropIndex(
                name: "IX_LearnerCourses_LearnerId",
                table: "LearnerCourses");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_InstitutionId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Events_InstitutionId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerInstitutions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InstitutionId",
                table: "LearnerInstitutions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerFundings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FundingId",
                table: "LearnerFundings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerEvents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "LearnerEvents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LearnerId",
                table: "LearnerCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "LearnerCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Courses",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Institutions",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Institution",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
