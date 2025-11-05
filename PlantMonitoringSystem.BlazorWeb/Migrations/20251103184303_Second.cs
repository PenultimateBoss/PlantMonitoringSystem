using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantMonitoringSystem.BlazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_Users_UserId",
                table: "Plant");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecord_Plant_PlantId",
                table: "SensorRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorRecord",
                table: "SensorRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plant",
                table: "Plant");

            migrationBuilder.RenameTable(
                name: "SensorRecord",
                newName: "SensorRecords");

            migrationBuilder.RenameTable(
                name: "Plant",
                newName: "Plants");

            migrationBuilder.RenameIndex(
                name: "IX_SensorRecord_PlantId",
                table: "SensorRecords",
                newName: "IX_SensorRecords_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Plant_UserId",
                table: "Plants",
                newName: "IX_Plants_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorRecords",
                table: "SensorRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Users_UserId",
                table: "Plants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorRecords_Plants_PlantId",
                table: "SensorRecords",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Users_UserId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorRecords_Plants_PlantId",
                table: "SensorRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorRecords",
                table: "SensorRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.RenameTable(
                name: "SensorRecords",
                newName: "SensorRecord");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "Plant");

            migrationBuilder.RenameIndex(
                name: "IX_SensorRecords_PlantId",
                table: "SensorRecord",
                newName: "IX_SensorRecord_PlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_UserId",
                table: "Plant",
                newName: "IX_Plant_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorRecord",
                table: "SensorRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plant",
                table: "Plant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_Users_UserId",
                table: "Plant",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorRecord_Plant_PlantId",
                table: "SensorRecord",
                column: "PlantId",
                principalTable: "Plant",
                principalColumn: "Id");
        }
    }
}
