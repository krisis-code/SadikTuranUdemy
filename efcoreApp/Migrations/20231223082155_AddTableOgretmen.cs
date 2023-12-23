using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOgretmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OgranciSoyad",
                table: "Ogrenciler",
                newName: "OgrenciSoyad");

            migrationBuilder.RenameColumn(
                name: "OgranciAd",
                table: "Ogrenciler",
                newName: "OgrenciAd");

            migrationBuilder.AddColumn<int>(
                name: "OgrentmenId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OgretmenAd = table.Column<string>(type: "TEXT", nullable: true),
                    OgretmenSoyad = table.Column<string>(type: "TEXT", nullable: true),
                    Eposta = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurskayitleri_KursId",
                table: "Kurskayitleri",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurskayitleri_OgrenciId",
                table: "Kurskayitleri",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurskayitleri_Kurslar_KursId",
                table: "Kurskayitleri",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurskayitleri_Ogrenciler_OgrenciId",
                table: "Kurskayitleri",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurskayitleri_Kurslar_KursId",
                table: "Kurskayitleri");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurskayitleri_Ogrenciler_OgrenciId",
                table: "Kurskayitleri");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropIndex(
                name: "IX_Kurskayitleri_KursId",
                table: "Kurskayitleri");

            migrationBuilder.DropIndex(
                name: "IX_Kurskayitleri_OgrenciId",
                table: "Kurskayitleri");

            migrationBuilder.DropColumn(
                name: "OgrentmenId",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "Kurslar");

            migrationBuilder.RenameColumn(
                name: "OgrenciSoyad",
                table: "Ogrenciler",
                newName: "OgranciSoyad");

            migrationBuilder.RenameColumn(
                name: "OgrenciAd",
                table: "Ogrenciler",
                newName: "OgranciAd");
        }
    }
}
