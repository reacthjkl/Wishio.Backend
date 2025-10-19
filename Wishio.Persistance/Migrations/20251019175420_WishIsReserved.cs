using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wishio.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class WishIsReserved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Wishes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Wishes");
        }
    }
}
