using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.TVShows.Forser.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTheNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TVShowId",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TVShowId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "TVShowId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "TVShowId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TVShowId",
                table: "Ratings",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_TVShowId",
                table: "Genres",
                column: "TVShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_TVShows_TVShowId",
                table: "Genres",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_TVShows_TVShowId",
                table: "Ratings",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_TVShows_TVShowId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_TVShows_TVShowId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_TVShowId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Genres_TVShowId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "TVShowId",
                table: "Genres");
        }
    }
}
