using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wishio.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BinaryData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    CustomThemePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Pictures_CustomThemePictureId",
                        column: x => x.CustomThemePictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wishlists_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WishlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishes_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wishes_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_PictureId",
                table: "Wishes",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_WishlistId",
                table: "Wishes",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_CustomThemePictureId",
                table: "Wishlists",
                column: "CustomThemePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_PictureId",
                table: "Wishlists",
                column: "PictureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wishes");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
