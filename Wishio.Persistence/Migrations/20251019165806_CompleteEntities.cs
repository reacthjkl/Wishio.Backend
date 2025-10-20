using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wishio.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CompleteEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomThemePictureId",
                table: "Wishlists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Wishlists",
                type: "TEXT",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId",
                table: "Wishlists",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Theme",
                table: "Wishlists",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "newid()"),
                    BinaryData = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ContentType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Link = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    PictureId = table.Column<Guid>(type: "TEXT", nullable: true),
                    WishlistId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                name: "IX_Wishlists_CustomThemePictureId",
                table: "Wishlists",
                column: "CustomThemePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_PictureId",
                table: "Wishlists",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_PictureId",
                table: "Wishes",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_WishlistId",
                table: "Wishes",
                column: "WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Pictures_CustomThemePictureId",
                table: "Wishlists",
                column: "CustomThemePictureId",
                principalTable: "Pictures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Pictures_PictureId",
                table: "Wishlists",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Pictures_CustomThemePictureId",
                table: "Wishlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Pictures_PictureId",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "Wishes");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_CustomThemePictureId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_PictureId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "CustomThemePictureId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Wishlists");
        }
    }
}
