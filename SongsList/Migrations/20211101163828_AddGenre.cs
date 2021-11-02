using Microsoft.EntityFrameworkCore.Migrations;

namespace SongsList.Migrations
{
    public partial class AddGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "Songs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "M", "Metal" },
                    { "R", "Rap" },
                    { "H", "Hip Hop" },
                    { "RC", "Rock" }
                });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenreId",
                value: "M");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "GenreId",
                value: "R");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3,
                column: "GenreId",
                value: "H");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Genres_GenreId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Songs_GenreId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Songs");
        }
    }
}
