using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalMonti.Infrastructure.Migrations
{
    public partial class InitialNewChat1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Messages");
        }
    }
}
