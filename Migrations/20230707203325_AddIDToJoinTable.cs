using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddIDToJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPrograms_Activities_ActivityId",
                table: "MeetingPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPrograms_Meetings_MeetingId",
                table: "MeetingPrograms");

            migrationBuilder.RenameColumn(
                name: "MeetingId",
                table: "MeetingPrograms",
                newName: "MeetingID");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "MeetingPrograms",
                newName: "ActivityID");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingPrograms_MeetingId",
                table: "MeetingPrograms",
                newName: "IX_MeetingPrograms_MeetingID");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingPrograms_ActivityId",
                table: "MeetingPrograms",
                newName: "IX_MeetingPrograms_ActivityID");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPrograms_Activities_ActivityID",
                table: "MeetingPrograms",
                column: "ActivityID",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPrograms_Meetings_MeetingID",
                table: "MeetingPrograms",
                column: "MeetingID",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPrograms_Activities_ActivityID",
                table: "MeetingPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPrograms_Meetings_MeetingID",
                table: "MeetingPrograms");

            migrationBuilder.RenameColumn(
                name: "MeetingID",
                table: "MeetingPrograms",
                newName: "MeetingId");

            migrationBuilder.RenameColumn(
                name: "ActivityID",
                table: "MeetingPrograms",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingPrograms_MeetingID",
                table: "MeetingPrograms",
                newName: "IX_MeetingPrograms_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingPrograms_ActivityID",
                table: "MeetingPrograms",
                newName: "IX_MeetingPrograms_ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPrograms_Activities_ActivityId",
                table: "MeetingPrograms",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPrograms_Meetings_MeetingId",
                table: "MeetingPrograms",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
