using Microsoft.EntityFrameworkCore.Migrations;

namespace SIDIMSClient.Api.Migrations
{
    public partial class UpdateModel04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalQtyIssued",
                table: "ClientStockReport",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQtyIssued",
                table: "ClientStockReport");
        }
    }
}
