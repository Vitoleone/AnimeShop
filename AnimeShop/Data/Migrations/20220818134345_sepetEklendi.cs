using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeShop.Data.Migrations
{
    public partial class sepetEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Miktar = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    SiparisOk = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sepet_AspNetUsers_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sepet_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_MusteriId",
                table: "Sepet",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_UrunId",
                table: "Sepet",
                column: "UrunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sepet");
        }
    }
}
