using Microsoft.EntityFrameworkCore.Migrations;

namespace Paging.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Raznovrsne čokolade", 4.99m },
                    { 2, "Razni čokoladni bomboni", 5.99m },
                    { 3, "M&M", 3.75m },
                    { 4, "Voćne žvake", 6.9m },
                    { 5, "Voćne lizalice", 2.9m },
                    { 6, "Voćni kiseli bomboni", 4.95m },
                    { 7, "Voćne uvezene žvake", 11.9m },
                    { 8, "Kisele žvake", 1.9m },
                    { 9, "Razni halloween bomboni", 3.5m },
                    { 10, "Tvrdi voćni bomboni", 9.9m },
                    { 11, "Razni tvrdi bomboni", 8.97m },
                    { 12, "Tvrdi kiseli bomboni", 5.55m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
