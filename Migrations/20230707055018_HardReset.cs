using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class HardReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Sacrament");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EventInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EventFooter = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
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
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClosingHymn = table.Column<int>(type: "int", nullable: false),
                    IntermidiateHymn = table.Column<int>(type: "int", nullable: true),
                    OpeningHymn = table.Column<int>(type: "int", nullable: false),
                    Performer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SacramentHymn = table.Column<int>(type: "int", nullable: false),
                    SpecialMusicalNum = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClosingPrayer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Conducting = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpeningPrayer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Presiding = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PeopleId);
                });

            migrationBuilder.CreateTable(
                name: "Sacrament",
                columns: table => new
                {
                    SacramentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HymnId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacrament", x => x.SacramentId);
                    table.ForeignKey(
                        name: "FK_Sacrament_Hymn_HymnId",
                        column: x => x.HymnId,
                        principalTable: "Hymn",
                        principalColumn: "HymnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sacrament_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacramentId = table.Column<int>(type: "int", nullable: false),
                    SpeakerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpeakerTopic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpeakerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                    table.ForeignKey(
                        name: "FK_Speaker_Sacrament_SacramentId",
                        column: x => x.SacramentId,
                        principalTable: "Sacrament",
                        principalColumn: "SacramentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sacrament_HymnId",
                table: "Sacrament",
                column: "HymnId");

            migrationBuilder.CreateIndex(
                name: "IX_Sacrament_PeopleId",
                table: "Sacrament",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SacramentId",
                table: "Speaker",
                column: "SacramentId");
        }
    }
}
