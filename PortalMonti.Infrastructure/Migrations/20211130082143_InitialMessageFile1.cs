using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalMonti.Infrastructure.Migrations
{
    public partial class InitialMessageFile1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Messages");
        }
    }
}
