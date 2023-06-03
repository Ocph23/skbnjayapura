using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skbnjayapura.Server.Migrations
{
    /// <inheritdoc />
    public partial class _permohonan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPersyaratan_Permohoans_PermohoanId",
                table: "ItemPersyaratan");

            migrationBuilder.DropTable(
                name: "Permohoans");

            migrationBuilder.RenameColumn(
                name: "PermohoanId",
                table: "ItemPersyaratan",
                newName: "PermohonanId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPersyaratan_PermohoanId",
                table: "ItemPersyaratan",
                newName: "IX_ItemPersyaratan_PermohonanId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalLahir",
                table: "Profiles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JenisKelamin",
                table: "Profiles",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permohonans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    Keperluan = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TanggalPengajuan = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SkbnId = table.Column<int>(type: "int", nullable: true),
                    Catatan = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permohonans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permohonans_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permohonans_SKBN_SkbnId",
                        column: x => x.SkbnId,
                        principalTable: "SKBN",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Permohonans_ProfileId",
                table: "Permohonans",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Permohonans_SkbnId",
                table: "Permohonans",
                column: "SkbnId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPersyaratan_Permohonans_PermohonanId",
                table: "ItemPersyaratan",
                column: "PermohonanId",
                principalTable: "Permohonans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPersyaratan_Permohonans_PermohonanId",
                table: "ItemPersyaratan");

            migrationBuilder.DropTable(
                name: "Permohonans");

            migrationBuilder.RenameColumn(
                name: "PermohonanId",
                table: "ItemPersyaratan",
                newName: "PermohoanId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPersyaratan_PermohonanId",
                table: "ItemPersyaratan",
                newName: "IX_ItemPersyaratan_PermohoanId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalLahir",
                table: "Profiles",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "JenisKelamin",
                keyValue: null,
                column: "JenisKelamin",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "JenisKelamin",
                table: "Profiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permohoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    SkbnId = table.Column<int>(type: "int", nullable: true),
                    Catatan = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Keperluan = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TanggalPengajuan = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permohoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permohoans_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permohoans_SKBN_SkbnId",
                        column: x => x.SkbnId,
                        principalTable: "SKBN",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Permohoans_ProfileId",
                table: "Permohoans",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Permohoans_SkbnId",
                table: "Permohoans",
                column: "SkbnId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPersyaratan_Permohoans_PermohoanId",
                table: "ItemPersyaratan",
                column: "PermohoanId",
                principalTable: "Permohoans",
                principalColumn: "Id");
        }
    }
}
