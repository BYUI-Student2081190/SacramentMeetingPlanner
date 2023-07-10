using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class EditiedActivityRelationWithMeetingProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_MeetingPrograms_MeetingProgramId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_MeetingProgramId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "MeetingProgramId",
                table: "Activities");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPrograms_ActivityId",
                table: "MeetingPrograms",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingPrograms_Activities_ActivityId",
                table: "MeetingPrograms",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingPrograms_Activities_ActivityId",
                table: "MeetingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_MeetingPrograms_ActivityId",
                table: "MeetingPrograms");

            migrationBuilder.AddColumn<int>(
                name: "MeetingProgramId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_MeetingProgramId",
                table: "Activities",
                column: "MeetingProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_MeetingPrograms_MeetingProgramId",
                table: "Activities",
                column: "MeetingProgramId",
                principalTable: "MeetingPrograms",
                principalColumn: "Id");
        }
    }
}
