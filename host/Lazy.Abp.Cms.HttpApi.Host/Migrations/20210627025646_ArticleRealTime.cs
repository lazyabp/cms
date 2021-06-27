using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lazy.Abp.Cms.Migrations
{
    public partial class ArticleRealTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RealTime",
                table: "CmsArticles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealTime",
                table: "CmsArticles");
        }
    }
}
