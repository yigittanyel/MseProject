using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSE.DataAccess.Migrations
{
    public partial class Manytomany_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkStationPersonnels",
                columns: table => new
                {
                    MaintenancePersonnelId = table.Column<int>(type: "int", nullable: false),
                    WorkStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_WorkStationPersonnels_MaintenancePersonnels_MaintenancePersonnelId",
                        column: x => x.MaintenancePersonnelId,
                        principalTable: "MaintenancePersonnels",
                        principalColumn: "MaintenancePersonnelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkStationPersonnels_WorkStations_WorkStationId",
                        column: x => x.WorkStationId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkStationPersonnels_MaintenancePersonnelId",
                table: "WorkStationPersonnels",
                column: "MaintenancePersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkStationPersonnels_WorkStationId",
                table: "WorkStationPersonnels",
                column: "WorkStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkStationPersonnels");
        }
    }
}
