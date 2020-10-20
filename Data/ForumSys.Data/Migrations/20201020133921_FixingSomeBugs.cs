using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumSys.Data.Migrations
{
    public partial class FixingSomeBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "IpAddress",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "IpAddress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "IpAddress",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "IpAddress",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "IpAddress",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IpAddress_IsDeleted",
                table: "IpAddress",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IpAddress_IsDeleted",
                table: "IpAddress");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "IpAddress");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "IpAddress");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "IpAddress");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "IpAddress");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "IpAddress");
        }
    }
}
