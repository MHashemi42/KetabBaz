using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KetabBaz.Infrastructure.Migrations
{
    public partial class ChangePrimaryKeyofView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Views",
                table: "Views");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Views",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateUpdated",
                table: "Views",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Views",
                table: "Views",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Views_BookId",
                table: "Views",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Views",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Views_BookId",
                table: "Views");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Views");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Views");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Views",
                table: "Views",
                column: "BookId");
        }
    }
}
