using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineDictionary.Migrations
{
    /// <inheritdoc />
    public partial class addforgotenforeignkeyfortranslatesinmtmtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_dicts_translates_translate_id",
                table: "dicts_translates",
                column: "translate_id");

            migrationBuilder.AddForeignKey(
                name: "FK_dicts_translates_translates_translate_id",
                table: "dicts_translates",
                column: "translate_id",
                principalTable: "translates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dicts_translates_translates_translate_id",
                table: "dicts_translates");

            migrationBuilder.DropIndex(
                name: "IX_dicts_translates_translate_id",
                table: "dicts_translates");
        }
    }
}
