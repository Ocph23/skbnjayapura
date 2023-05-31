using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skbnjayapura.Server.Migrations
{
    /// <inheritdoc />
    public partial class _persyaratan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPersyaratan_Persyaratan_PersyaratanId",
                table: "ItemPersyaratan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persyaratan",
                table: "Persyaratan");

            migrationBuilder.RenameTable(
                name: "Persyaratan",
                newName: "Persyaratans");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persyaratans",
                table: "Persyaratans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPersyaratan_Persyaratans_PersyaratanId",
                table: "ItemPersyaratan",
                column: "PersyaratanId",
                principalTable: "Persyaratans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPersyaratan_Persyaratans_PersyaratanId",
                table: "ItemPersyaratan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persyaratans",
                table: "Persyaratans");

            migrationBuilder.RenameTable(
                name: "Persyaratans",
                newName: "Persyaratan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persyaratan",
                table: "Persyaratan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPersyaratan_Persyaratan_PersyaratanId",
                table: "ItemPersyaratan",
                column: "PersyaratanId",
                principalTable: "Persyaratan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
