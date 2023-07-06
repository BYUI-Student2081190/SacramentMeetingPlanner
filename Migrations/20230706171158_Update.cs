using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_People_PeopleId",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "PeopleId",
                table: "Speaker",
                newName: "SacramentId");

            migrationBuilder.RenameIndex(
                name: "IX_Speaker_PeopleId",
                table: "Speaker",
                newName: "IX_Speaker_SacramentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Sacrament_SacramentId",
                table: "Speaker",
                column: "SacramentId",
                principalTable: "Sacrament",
                principalColumn: "SacramentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Sacrament_SacramentId",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "SacramentId",
                table: "Speaker",
                newName: "PeopleId");

            migrationBuilder.RenameIndex(
                name: "IX_Speaker_SacramentId",
                table: "Speaker",
                newName: "IX_Speaker_PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_People_PeopleId",
                table: "Speaker",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "PeopleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
