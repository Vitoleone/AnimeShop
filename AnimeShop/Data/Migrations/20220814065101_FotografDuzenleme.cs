using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeShop.Data.Migrations
{
    public partial class FotografDuzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Fotograf_UrunId",
                table: "Fotograf");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Urun_UrunId1",
                table: "Fotograf");

            migrationBuilder.DropIndex(
                name: "IX_Fotograf_UrunId1",
                table: "Fotograf");

            migrationBuilder.DropColumn(
                name: "UrunId1",
                table: "Fotograf");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Urun_UrunId",
                table: "Fotograf",
                column: "UrunId",
                principalTable: "Urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotograf_Urun_UrunId",
                table: "Fotograf");

            migrationBuilder.AddColumn<int>(
                name: "UrunId1",
                table: "Fotograf",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fotograf_UrunId1",
                table: "Fotograf",
                column: "UrunId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Fotograf_UrunId",
                table: "Fotograf",
                column: "UrunId",
                principalTable: "Fotograf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fotograf_Urun_UrunId1",
                table: "Fotograf",
                column: "UrunId1",
                principalTable: "Urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
