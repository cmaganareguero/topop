using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace topop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VideoAtributtes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                schema: "dbo",
                table: "Videos",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Videos",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Anime",
                schema: "dbo",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anime",
                schema: "dbo",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "dbo",
                table: "Videos",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "dbo",
                table: "Videos",
                newName: "Name");
        }
    }
}
