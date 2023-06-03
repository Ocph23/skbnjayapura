using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skbnjayapura.Server.Migrations
{
    /// <inheritdoc />
    public partial class _permohonanStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Permohonans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Verifikasi",
                table: "ItemPersyaratan",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Permohonans");

            migrationBuilder.DropColumn(
                name: "Verifikasi",
                table: "ItemPersyaratan");
        }
    }
}
