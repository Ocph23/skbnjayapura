using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skbnjayapura.Server.Migrations
{
    /// <inheritdoc />
    public partial class _modifySKBN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomorSKPN",
                table: "SKBN",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalSKPN",
                table: "SKBN",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomorSKPN",
                table: "SKBN");

            migrationBuilder.DropColumn(
                name: "TanggalSKPN",
                table: "SKBN");
        }
    }
}
