using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumSys.Data.Migrations
{
    public partial class FixingSomeBugses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginsCount",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginsCount",
                table: "AspNetUsers");
        }
    }
}
