using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace topop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Rankings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRankings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RankingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRankings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRankings_Rankings_RankingId",
                        column: x => x.RankingId,
                        principalSchema: "dbo",
                        principalTable: "Rankings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRankings_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoRankings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    RankingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoRankings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoRankings_Rankings_RankingId",
                        column: x => x.RankingId,
                        principalSchema: "dbo",
                        principalTable: "Rankings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoRankings_Videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "dbo",
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVideoRankings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VideoRankingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVideoRankings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVideoRankings_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVideoRankings_VideoRankings_VideoRankingId",
                        column: x => x.VideoRankingId,
                        principalSchema: "dbo",
                        principalTable: "VideoRankings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRankings_RankingId",
                schema: "dbo",
                table: "UserRankings",
                column: "RankingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRankings_UserId",
                schema: "dbo",
                table: "UserRankings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVideoRankings_UserId",
                schema: "dbo",
                table: "UserVideoRankings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVideoRankings_VideoRankingId",
                schema: "dbo",
                table: "UserVideoRankings",
                column: "VideoRankingId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoRankings_RankingId",
                schema: "dbo",
                table: "VideoRankings",
                column: "RankingId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoRankings_VideoId",
                schema: "dbo",
                table: "VideoRankings",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRankings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserVideoRankings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VideoRankings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Rankings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Videos",
                schema: "dbo");
        }
    }
}
