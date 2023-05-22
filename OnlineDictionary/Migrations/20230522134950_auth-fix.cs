using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineDictionary.Migrations
{
    /// <inheritdoc />
    public partial class authfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogined",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogined",
                table: "users");
        }
    }
}
