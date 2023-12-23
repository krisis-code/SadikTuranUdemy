using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOgretmens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurskayitleri_Kurslar_KursId",
                table: "Kurskayitleri");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurskayitleri_Ogrenciler_OgrenciId",
                table: "Kurskayitleri");

            migrationBuilder.AlterColumn<int>(
                name: "OgrenciId",
                table: "Kurskayitleri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "KursId",
                table: "Kurskayitleri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurskayitleri_Kurslar_KursId",
                table: "Kurskayitleri",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurskayitleri_Ogrenciler_OgrenciId",
                table: "Kurskayitleri",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId");
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

            migrationBuilder.AlterColumn<int>(
                name: "OgrenciId",
                table: "Kurskayitleri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KursId",
                table: "Kurskayitleri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
        }
    }
}
