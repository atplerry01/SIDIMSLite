using Microsoft.EntityFrameworkCore.Migrations;

namespace SIDIMSClient.Api.Migrations
{
    public partial class UpdateModel03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStock",
                table: "ClientStockReport",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "ClientStockReport");
        }
    }
}
