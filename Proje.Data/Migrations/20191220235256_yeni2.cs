using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Data.Migrations
{
    public partial class yeni2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentAuthor",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentImg",
                table: "Content",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentAuthor",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContentImg",
                table: "Content");
        }
    }
}
