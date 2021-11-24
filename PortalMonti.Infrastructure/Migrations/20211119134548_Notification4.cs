using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalMonti.Infrastructure.Migrations
{
    public partial class Notification4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Notifications");
        }
    }
}
