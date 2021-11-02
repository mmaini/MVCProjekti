using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsList.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 1, "Pjesma 1", 5, 1980 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 2, "Pjesma 2", 4, 1990 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "Rating", "Year" },
                values: new object[] { 3, "Pjesma 3", 1, 2005 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
