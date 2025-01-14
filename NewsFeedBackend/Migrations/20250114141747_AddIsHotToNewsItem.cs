using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsFeedBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddIsHotToNewsItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHot",
                table: "NewsItems",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHot",
                table: "NewsItems");
        }
    }
}
