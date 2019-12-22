using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Data.Migrations
{
    public partial class modifyContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentImgPath",
                table: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentImgPath",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
