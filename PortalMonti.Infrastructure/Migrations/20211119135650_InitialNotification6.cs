using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalMonti.Infrastructure.Migrations
{
    public partial class InitialNotification6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Notifications");
        }
    }
}
