using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddressOfMeeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Meetings",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Meetings");
        }
    }
}
