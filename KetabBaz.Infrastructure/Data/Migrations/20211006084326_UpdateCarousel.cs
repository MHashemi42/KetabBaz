using Microsoft.EntityFrameworkCore.Migrations;

namespace KetabBaz.Infrastructure.Migrations
{
    public partial class UpdateCarousel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainCarousel",
                table: "Carousels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainCarousel",
                table: "Carousels");
        }
    }
}
