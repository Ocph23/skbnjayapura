using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skbnjayapura.Server.Migrations
{
    /// <inheritdoc />
    public partial class persetujuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiSetujuiOlehId",
                table: "SKBN",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SKBN_DiSetujuiOlehId",
                table: "SKBN",
                column: "DiSetujuiOlehId");

            migrationBuilder.AddForeignKey(
                name: "FK_SKBN_Pimpinans_DiSetujuiOlehId",
                table: "SKBN",
                column: "DiSetujuiOlehId",
                principalTable: "Pimpinans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SKBN_Pimpinans_DiSetujuiOlehId",
                table: "SKBN");

            migrationBuilder.DropIndex(
                name: "IX_SKBN_DiSetujuiOlehId",
                table: "SKBN");

            migrationBuilder.DropColumn(
                name: "DiSetujuiOlehId",
                table: "SKBN");
        }
    }
}
