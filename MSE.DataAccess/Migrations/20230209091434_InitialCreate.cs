using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSE.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarms",
                columns: table => new
                {
                    AlarmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.AlarmId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePersonnels",
                columns: table => new
                {
                    MaintenancePersonnelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePersonnels", x => x.MaintenancePersonnelId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionLines",
                columns: table => new
                {
                    ProductionLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionLineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLines", x => x.ProductionLineId);
                });

            migrationBuilder.CreateTable(
                name: "WorkStations",
                columns: table => new
                {
                    WorkStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Temperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ProductionLineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStations", x => x.WorkStationId);
                    table.ForeignKey(
                        name: "FK_WorkStations_ProductionLines_ProductionLineId",
                        column: x => x.ProductionLineId,
                        principalTable: "ProductionLines",
                        principalColumn: "ProductionLineId");
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePersonnelWorkStation",
                columns: table => new
                {
                    MaintenancePersonnelsMaintenancePersonnelId = table.Column<int>(type: "int", nullable: false),
                    WorkStationsWorkStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePersonnelWorkStation", x => new { x.MaintenancePersonnelsMaintenancePersonnelId, x.WorkStationsWorkStationId });
                    table.ForeignKey(
                        name: "FK_MaintenancePersonnelWorkStation_MaintenancePersonnels_MaintenancePersonnelsMaintenancePersonnelId",
                        column: x => x.MaintenancePersonnelsMaintenancePersonnelId,
                        principalTable: "MaintenancePersonnels",
                        principalColumn: "MaintenancePersonnelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenancePersonnelWorkStation_WorkStations_WorkStationsWorkStationId",
                        column: x => x.WorkStationsWorkStationId,
                        principalTable: "WorkStations",
                        principalColumn: "WorkStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePersonnelWorkStation_WorkStationsWorkStationId",
                table: "MaintenancePersonnelWorkStation",
                column: "WorkStationsWorkStationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkStations_ProductionLineId",
                table: "WorkStations",
                column: "ProductionLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarms");

            migrationBuilder.DropTable(
                name: "MaintenancePersonnelWorkStation");

            migrationBuilder.DropTable(
                name: "MaintenancePersonnels");

            migrationBuilder.DropTable(
                name: "WorkStations");

            migrationBuilder.DropTable(
                name: "ProductionLines");
        }
    }
}
