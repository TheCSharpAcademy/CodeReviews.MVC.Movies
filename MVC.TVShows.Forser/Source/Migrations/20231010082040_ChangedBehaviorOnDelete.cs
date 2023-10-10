using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.TVShows.Forser.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBehaviorOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Genre_Genres_Genre_Id",
                table: "TVShow_Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Genre_TVShows_TVShow_Id",
                table: "TVShow_Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Rating_Ratings_Rating_Id",
                table: "TVShow_Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Rating_TVShows_TVShow_Id",
                table: "TVShow_Rating");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Genre_Genres_Genre_Id",
                table: "TVShow_Genre",
                column: "Genre_Id",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Genre_TVShows_TVShow_Id",
                table: "TVShow_Genre",
                column: "TVShow_Id",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Rating_Ratings_Rating_Id",
                table: "TVShow_Rating",
                column: "Rating_Id",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Rating_TVShows_TVShow_Id",
                table: "TVShow_Rating",
                column: "TVShow_Id",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Genre_Genres_Genre_Id",
                table: "TVShow_Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Genre_TVShows_TVShow_Id",
                table: "TVShow_Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Rating_Ratings_Rating_Id",
                table: "TVShow_Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Rating_TVShows_TVShow_Id",
                table: "TVShow_Rating");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Genre_Genres_Genre_Id",
                table: "TVShow_Genre",
                column: "Genre_Id",
                principalTable: "Genres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Genre_TVShows_TVShow_Id",
                table: "TVShow_Genre",
                column: "TVShow_Id",
                principalTable: "TVShows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Rating_Ratings_Rating_Id",
                table: "TVShow_Rating",
                column: "Rating_Id",
                principalTable: "Ratings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Rating_TVShows_TVShow_Id",
                table: "TVShow_Rating",
                column: "TVShow_Id",
                principalTable: "TVShows",
                principalColumn: "Id");
        }
    }
}
