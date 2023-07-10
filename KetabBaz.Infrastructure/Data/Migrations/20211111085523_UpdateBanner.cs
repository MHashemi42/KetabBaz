using Microsoft.EntityFrameworkCore.Migrations;

namespace KetabBaz.Infrastructure.Migrations
{
    public partial class UpdateBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Banners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Banners");
        }
    }
}
