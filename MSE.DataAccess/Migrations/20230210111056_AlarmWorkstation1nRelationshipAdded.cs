using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSE.DataAccess.Migrations
{
    public partial class AlarmWorkstation1nRelationshipAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkStationId",
                table: "Alarms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_WorkStationId",
                table: "Alarms",
                column: "WorkStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_WorkStations_WorkStationId",
                table: "Alarms",
                column: "WorkStationId",
                principalTable: "WorkStations",
                principalColumn: "WorkStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarms_WorkStations_WorkStationId",
                table: "Alarms");

            migrationBuilder.DropIndex(
                name: "IX_Alarms_WorkStationId",
                table: "Alarms");

            migrationBuilder.DropColumn(
                name: "WorkStationId",
                table: "Alarms");
        }
    }
}
