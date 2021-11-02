using Microsoft.EntityFrameworkCore.Migrations;

namespace CandyShop.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Čokolade" },
                    { 2, "Voćni bomboni" },
                    { 3, "Gumeni bomboni" },
                    { 4, "Halloween bomboni" },
                    { 5, "Tvrdi bomboni" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Raznovrsne_čokolade", 0m, "Raznovrsne čokolade", 4.99m },
                    { 2, 1, "Čokoladni_mix", 0m, "Razni čokoladni bomboni", 5.99m },
                    { 3, 1, "Čokoladni_MMS", 0m, "M&M", 3.75m },
                    { 4, 2, "Voćne_žvake", 0m, "Voćne žvake", 6.9m },
                    { 5, 2, "Voćne_lizalice", 0m, "Voćne lizalice", 2.9m },
                    { 6, 2, "Voćni_kiseli", 0m, "Voćni kiseli bomboni", 4.95m },
                    { 7, 3, "Uvezene_žvake", 0m, "Voćne uvezene žvake", 11.9m },
                    { 8, 3, "Kisele_žvake", 0m, "Kisele žvake", 1.9m },
                    { 9, 4, "Razni_halloween", 0m, "Razni halloween bomboni", 3.5m },
                    { 10, 5, "Tvrdi_voćni", 0m, "Tvrdi voćni bomboni", 9.9m },
                    { 11, 5, "Razni_tvrdi", 0m, "Razni tvrdi bomboni", 8.97m },
                    { 12, 5, "Tvrdi_kiseli", 0m, "Tvrdi kiseli bomboni", 5.55m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
