using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsFeedBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorToNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "NewsItems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "NewsItems");
        }
    }
}
