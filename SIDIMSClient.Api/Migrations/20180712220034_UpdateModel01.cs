using Microsoft.EntityFrameworkCore.Migrations;

namespace SIDIMSClient.Api.Migrations
{
    public partial class UpdateModel01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnQty",
                table: "ClientStockReport");

            migrationBuilder.DropColumn(
                name: "TotalQtyIssued",
                table: "ClientStockReport");

            migrationBuilder.DropColumn(
                name: "WasteQty",
                table: "ClientStockReport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReturnQty",
                table: "ClientStockReport",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalQtyIssued",
                table: "ClientStockReport",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WasteQty",
                table: "ClientStockReport",
                nullable: true);
        }
    }
}
