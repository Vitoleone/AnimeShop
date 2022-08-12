using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeShop.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cinsiyet",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sehir",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UyeOlmaTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kampanya",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirimOran = table.Column<double>(type: "float", nullable: false),
                    MinimumDeger = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kampanya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GondermeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KargoFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KargoUcreti = table.Column<double>(type: "float", nullable: false),
                    ToplamUcret = table.Column<double>(type: "float", nullable: false),
                    Indirim = table.Column<double>(type: "float", nullable: false),
                    SiparisDurumu = table.Column<int>(type: "int", nullable: false),
                    OdemeDurumu = table.Column<int>(type: "int", nullable: false),
                    SiparisKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KargoTakipNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparis_AspNetUsers_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    Miktar = table.Column<double>(type: "float", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UretimYeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urun_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fotograf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResimAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    UrunId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotograf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotograf_Fotograf_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Fotograf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fotograf_Urun_UrunId1",
                        column: x => x.UrunId1,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndirimliUrunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Oran = table.Column<double>(type: "float", nullable: false),
                    Baslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DigerKampanya = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndirimliUrunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndirimliUrunler_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Siparis_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotograf_UrunId",
                table: "Fotograf",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Fotograf_UrunId1",
                table: "Fotograf",
                column: "UrunId1");

            migrationBuilder.CreateIndex(
                name: "IX_IndirimliUrunler_UrunId",
                table: "IndirimliUrunler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_MusteriId",
                table: "Siparis",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisId",
                table: "SiparisDetay",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_UrunId",
                table: "SiparisDetay",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriId",
                table: "Urun",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotograf");

            migrationBuilder.DropTable(
                name: "IndirimliUrunler");

            migrationBuilder.DropTable(
                name: "Kampanya");

            migrationBuilder.DropTable(
                name: "SiparisDetay");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sehir",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UyeOlmaTarihi",
                table: "AspNetUsers");
        }
    }
}
