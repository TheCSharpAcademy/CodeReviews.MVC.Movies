using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC.TVShows.Forser.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowGenre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeasons = table.Column<int>(type: "int", nullable: false),
                    BeenWatched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TVShow_Rating",
                columns: table => new
                {
                    TVShow_Id = table.Column<int>(type: "int", nullable: false),
                    Rating_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShow_Rating", x => new { x.TVShow_Id, x.Rating_Id });
                    table.ForeignKey(
                        name: "FK_TVShow_Rating_Ratings_Rating_Id",
                        column: x => x.Rating_Id,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShow_Rating_TVShows_TVShow_Id",
                        column: x => x.TVShow_Id,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TVShowGenres",
                columns: table => new
                {
                    TVShow_Id = table.Column<int>(type: "int", nullable: false),
                    Genre_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowGenres", x => new { x.TVShow_Id, x.Genre_Id });
                    table.ForeignKey(
                        name: "FK_TVShowGenres_Genres_Genre_Id",
                        column: x => x.Genre_Id,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TVShowGenres_TVShows_TVShow_Id",
                        column: x => x.TVShow_Id,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Checked", "ShowGenre" },
                values: new object[,]
                {
                    { 1, false, "Action Comedy" },
                    { 2, false, "Adult Chat" },
                    { 3, false, "Animated Series" },
                    { 4, false, "Animated Sitcom" },
                    { 5, false, "Anthology Series" },
                    { 6, false, "Apocalyptic and Post-Apocalyptic Fiction" },
                    { 7, false, "Archive Television Program" },
                    { 8, false, "Breakfast Television" },
                    { 9, false, "Casting Television" },
                    { 10, false, "Children's Television Series" },
                    { 11, false, "Chopshocky" },
                    { 12, false, "Comedy Drama" },
                    { 13, false, "Cooking Show" },
                    { 14, false, "Court Show" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Certification", "Country", "Description", "IsSelected" },
                values: new object[,]
                {
                    { 1, "TV-Y", "USA", "This program is designed to be appropriate for all children.", false },
                    { 2, "TV-Y7", "USA", "This program is designed for children age 7 and above.", false },
                    { 3, "TV-G", "USA", "Most parents will find this program suitable for all ages.", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVShow_Rating_Rating_Id",
                table: "TVShow_Rating",
                column: "Rating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TVShowGenres_Genre_Id",
                table: "TVShowGenres",
                column: "Genre_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVShow_Rating");

            migrationBuilder.DropTable(
                name: "TVShowGenres");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "TVShows");
        }
    }
}
