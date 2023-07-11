using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeetingLocation",
                table: "Activities",
                newName: "MeetingID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Activities",
                newName: "ActivityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeetingID",
                table: "Activities",
                newName: "MeetingLocation");

            migrationBuilder.RenameColumn(
                name: "ActivityID",
                table: "Activities",
                newName: "Id");
        }
    }
}
