using Microsoft.EntityFrameworkCore.Migrations;

namespace SongList.Migrations
{
    public partial class SongsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "GenreId", "Name", "Rating", "Year" },
                values: new object[] { 1, (byte)2, "Take Control", 5, 2020 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "GenreId", "Name", "Rating", "Year" },
                values: new object[] { 2, (byte)4, "Dr. Stone", 4, 2019 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2);
        }
    }
}
