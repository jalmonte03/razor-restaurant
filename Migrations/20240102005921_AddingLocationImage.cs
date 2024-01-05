using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Website.Migrations
{
    /// <inheritdoc />
    public partial class AddingLocationImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationImage",
                table: "locations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationImage",
                table: "locations");
        }
    }
}
