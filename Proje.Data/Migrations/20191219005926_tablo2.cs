using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Data.Migrations
{
    public partial class tablo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: false),
                    CategoryOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(nullable: false),
                    ContentTime = table.Column<DateTime>(nullable: false),
                    ContentImgPath = table.Column<string>(nullable: true),
                    ContentName = table.Column<string>(nullable: true),
                    ContentDetail = table.Column<string>(nullable: true),
                    ContentState = table.Column<bool>(nullable: false),
                    ContentKeywords = table.Column<string>(nullable: true),
                    ContentHit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Content_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentID = table.Column<int>(nullable: false),
                    CommentContent = table.Column<string>(nullable: true),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    CommentRating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Content_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Content",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ContentID",
                table: "Comment",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CategoryID",
                table: "Content",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Content");
        }
    }
}
