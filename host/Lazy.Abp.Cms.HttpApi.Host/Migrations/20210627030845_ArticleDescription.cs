using Microsoft.EntityFrameworkCore.Migrations;

namespace Lazy.Abp.Cms.Migrations
{
    public partial class ArticleDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descritpion",
                table: "CmsArticles",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CmsArticles",
                newName: "Descritpion");
        }
    }
}
