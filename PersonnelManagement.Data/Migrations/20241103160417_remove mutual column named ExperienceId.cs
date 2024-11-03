using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonnelManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class removemutualcolumnnamedExperienceId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "ProfessionalExperiences");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Certificates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "ProfessionalExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
