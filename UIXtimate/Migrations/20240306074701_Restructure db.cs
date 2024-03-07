using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UIXtimate.Migrations
{
    /// <inheritdoc />
    public partial class Restructuredb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FigmasUrls",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImagesUrls",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PostVisualContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostVisualContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostVisualContents_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinReputation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRanks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RankId",
                table: "AspNetUsers",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_PostVisualContents_PostId",
                table: "PostVisualContents",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserRanks_RankId",
                table: "AspNetUsers",
                column: "RankId",
                principalTable: "UserRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserRanks_RankId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PostVisualContents");

            migrationBuilder.DropTable(
                name: "UserRanks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RankId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FigmasUrls",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagesUrls",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
