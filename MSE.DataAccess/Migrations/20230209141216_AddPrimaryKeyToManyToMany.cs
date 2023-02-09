using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSE.DataAccess.Migrations
{
    public partial class AddPrimaryKeyToManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WorkStationPersonnels",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkStationPersonnels",
                table: "WorkStationPersonnels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkStationPersonnels",
                table: "WorkStationPersonnels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkStationPersonnels");
        }
    }
}
