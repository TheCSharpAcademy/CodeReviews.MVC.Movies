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
                    ShowGenre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "TVShow_Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TVShow_Id = table.Column<int>(type: "int", nullable: true),
                    Genre_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShow_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVShow_Genre_Genres_Genre_Id",
                        column: x => x.Genre_Id,
                        principalTable: "Genres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TVShow_Genre_TVShows_TVShow_Id",
                        column: x => x.TVShow_Id,
                        principalTable: "TVShows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TVShow_Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TVShow_Id = table.Column<int>(type: "int", nullable: true),
                    Rating_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShow_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVShow_Rating_Ratings_Rating_Id",
                        column: x => x.Rating_Id,
                        principalTable: "Ratings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TVShow_Rating_TVShows_TVShow_Id",
                        column: x => x.TVShow_Id,
                        principalTable: "TVShows",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "ShowGenre" },
                values: new object[,]
                {
                    { 1, "Action Comedy" },
                    { 2, "Adult Chat" },
                    { 3, "Animated Series" },
                    { 4, "Animated Sitcom" },
                    { 5, "Anthology Series" },
                    { 6, "Apocalyptic and Post-Apocalyptic Fiction" },
                    { 7, "Archive Television Program" },
                    { 8, "Breakfast Television" },
                    { 9, "Casting Television" },
                    { 10, "Children's Television Series" },
                    { 11, "Chopshocky" },
                    { 12, "Comedy Drama" },
                    { 13, "Cooking Show" },
                    { 14, "Court Show" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Certification", "Country", "Description" },
                values: new object[,]
                {
                    { 1, "TV-Y", "USA", "This program is designed to be appropriate for all children." },
                    { 2, "TV-Y7", "USA", "This program is designed for children age 7 and above." },
                    { 3, "TV-G", "USA", "Most parents will find this program suitable for all ages." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TVShow_Genre_Genre_Id",
                table: "TVShow_Genre",
                column: "Genre_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TVShow_Genre_TVShow_Id",
                table: "TVShow_Genre",
                column: "TVShow_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TVShow_Rating_Rating_Id",
                table: "TVShow_Rating",
                column: "Rating_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TVShow_Rating_TVShow_Id",
                table: "TVShow_Rating",
                column: "TVShow_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVShow_Genre");

            migrationBuilder.DropTable(
                name: "TVShow_Rating");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "TVShows");
        }
    }
}
