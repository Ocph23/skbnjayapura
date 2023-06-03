using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skbnjayapura.Server.Migrations
{
    /// <inheritdoc />
    public partial class _nik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomorNIK",
                table: "Profiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomorNIK",
                table: "Profiles");
        }
    }
}
