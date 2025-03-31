using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsFeedBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddLargeContentMarker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasLargeContent",
                table: "NewsItems",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasLargeContent",
                table: "NewsItems");
        }
    }
}
