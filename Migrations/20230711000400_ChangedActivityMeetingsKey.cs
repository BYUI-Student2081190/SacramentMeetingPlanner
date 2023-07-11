using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class ChangedActivityMeetingsKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeetingID",
                table: "Activities",
                newName: "MeetingLocation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeetingLocation",
                table: "Activities",
                newName: "MeetingID");
        }
    }
}
