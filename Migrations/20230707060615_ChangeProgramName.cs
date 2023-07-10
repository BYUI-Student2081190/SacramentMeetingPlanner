using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProgramName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.AddColumn<int>(
                name: "MeetingProgramId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MeetingPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingPrograms_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_MeetingProgramId",
                table: "Activities",
                column: "MeetingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingPrograms_MeetingId",
                table: "MeetingPrograms",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_MeetingPrograms_MeetingProgramId",
                table: "Activities",
                column: "MeetingProgramId",
                principalTable: "MeetingPrograms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_MeetingPrograms_MeetingProgramId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "MeetingPrograms");

            migrationBuilder.DropIndex(
                name: "IX_Activities_MeetingProgramId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "MeetingProgramId",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });
        }
    }
}
