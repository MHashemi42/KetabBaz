using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KetabBaz.Infrastructure.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "244c44f3-1b75-4682-be4b-790f79562f7a", "2bf42853-3c19-455d-9d33-15b7af446012", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "244c44f3-1b75-4682-be4b-790f79562f7a");
        }
    }
}
