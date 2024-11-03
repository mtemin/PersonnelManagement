using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonnelManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class LeaveDaytablerefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LeaveStartDay",
                table: "LeaveDays",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "LeaveEndDay",
                table: "LeaveDays",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "LeaveDays",
                newName: "LeaveStartDay");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "LeaveDays",
                newName: "LeaveEndDay");
        }
    }
}
